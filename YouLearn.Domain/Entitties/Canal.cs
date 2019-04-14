using System;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Entitties.Base;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entitties
{
    public class Canal : EntityBase
    {
        public Canal(string nome, string urlLogo, User user)
        {
            Nome = nome;
            UrlLogo = urlLogo;
            User = user;

            new AddNotifications<Canal>(this)
                .IfNullOrInvalidLength(x => x.Nome, 2, 50,MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("2", "50") )
                .IfNullOrInvalidLength(x => x.UrlLogo, 4, 200, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("4","200"));

            AddNotifications(user);
        }

        public string Nome { get; private set; }

        public string UrlLogo { get; private set; }

        public User User { get; private set; }
    }
}
