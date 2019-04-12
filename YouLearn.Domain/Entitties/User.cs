using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entitties.Base;
using YouLearn.Domain.Extensions;
using YouLearn.Domain.ValueObject;

namespace YouLearn.Domain.Entitties
{
    public class User : EntityBase
    {
        public User()
        {

        }

        public User(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            new AddNotifications<User>(this).IfNullOrInvalidLength(x => x.Senha, 3, 32);

            Senha = Senha.ConvertToMD5();

            AddNotifications(nome, email);
        }

        public User(Email email, string senha)
        {
            Email = email;
            Senha = senha;
            Senha = Senha.ConvertToMD5();

            AddNotifications(email);
        }

        public Nome Nome{ get; private set; }        

        public Email Email { get; private set; }

        public string Senha { get; private set; }

    }

    public class Class1
    {
    }
}
