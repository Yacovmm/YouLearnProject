using System;
using YouLearn.Domain.Entitties.Base;

namespace YouLearn.Domain.Entitties
{
    public class Canal : EntityBase
    {
        public string Nome { get; set; }

        public string UrlLogo { get; set; }

        public User User { get; set; }

    }
}
