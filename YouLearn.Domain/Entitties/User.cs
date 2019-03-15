using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entitties.Base;
using YouLearn.Domain.ValueObject;

namespace YouLearn.Domain.Entitties
{
    public class User : EntityBase
    {
        public Nome Nome{ get; set; }        

        public Email Email { get; set; }

        public string Senha { get; set; }

    }
}
