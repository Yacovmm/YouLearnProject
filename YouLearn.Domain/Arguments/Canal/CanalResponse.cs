using System;
using YouLearn.Domain.Entitties;

namespace YouLearn.Domain.Arguments.Canal
{
    public class CanalResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UrlLogo { get; set; }

        public static explicit operator CanalResponse(Entitties.Canal v)
        {
            return new CanalResponse()
            {
                Name = v.Nome,
                UrlLogo = v.UrlLogo,
                Id = v.Id
            };
        }
    }
}
