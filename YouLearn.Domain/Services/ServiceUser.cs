using System;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Entitties;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObject;

namespace YouLearn.Domain.Services
{
    public class ServiceUser : Notifiable, IServiceUser
    {
        public AddUserResponse AddUser(AddUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AdicionarUserRequest", (MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUserRequest")));
                return null;
            }
                
                

            var user = new User
            {
                Nome = new Nome(request.FirstName, request.LastName),
                Email = new Email(request.Email),
                Senha = request.Senha
            };
            AddNotifications(user.Nome, user.Email);


            

            if (user.Senha.Length <= 3 )
                throw new Exception("Senha deve ser maior que 3 caracteres");

            //Persiste no Banco
            if (IsInvalid())
                return null;
            return new AddUserResponse(Guid.NewGuid());

        }

        public AutentificarUserResponse AutentificarUser(AutentificarUserRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
