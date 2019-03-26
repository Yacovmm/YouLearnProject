using System;
using System.Runtime.InteropServices.ComTypes;
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
        //Dependencies
        private readonly IRepositoryUser _repositoryUser;

        //Construtor
        public ServiceUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public AddUserResponse AddUser(AddUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AdicionarUserRequest", (MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarUserRequest")));
                return null;
            }


            //Cria value Object e entidades
            var user = new User(
                new Nome(request.FirstName, request.LastName),
                new Email(request.Email),
                request.Senha
                );
            
            AddNotifications(user);

            if (IsInvalid()) return null;
            
            //Persiste no Banco
            _repositoryUser.Save(user);

            return new AddUserResponse(user.Id);
        }

        public AutentificarUserResponse AutentificarUser(AutentificarUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AutentificarUserResponse", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AutentificarUserRequest"));
                return null;
            }

//            var email = new Email(request.Email);
//            var user = new 

            var user = new User(
                request.Email,
                request.Senha
                );
            
            AddNotifications(user);

            if (this.IsInvalid()) return null;

            user = _repositoryUser.Obter(user.Email.Endereco, user.Senha);

            if (user == null)
            {
                AddNotification("User", MSG.DADOS_NAO_ENCONTRADOS);
            }

            var response = (AutentificarUserResponse) user;

            return response;
        }
    }
}
