using System;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Entitties;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;

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
                Nome = {FirstName = "Yacov", LastName = "Rosenberg"},
                Email = {Endereco = "yayaro94@gmail.com"},
                Senha = "123456"
            };

            if(user.Nome.FirstName.Length < 3 || user.Nome.FirstName.Length > 50)
                throw new Exception("Primeiro nome é obrigatório e deve conter entre 3 e 50 caracteres");

            if (user.Nome.FirstName.Length < 3 || user.Nome.FirstName.Length > 50)
                throw new Exception("Primeiro nome é obrigatório e deve conter entre 3 e 50 caracteres");

            if (user.Email.Endereco.IndexOf('@') < 1)
                throw new Exception("Email inválido");

            if (user.Senha.Length >= 3 )
                throw new Exception("Senha deve ser maior que 3 caracteres");

            //Persiste no Banco
            return user;

        }

        public AutentificarUserResponse AutentificarUser(AutentificarUserRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
