using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.ValueObject
{
    public class Nome : Notifiable
    {
        public Nome(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.FirstName, 3, 50, MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat(firstName, 1 , 50))
                .IfNullOrInvalidLength(x => x.LastName, 3, 50 , MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat(LastName, 3, 50));
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
