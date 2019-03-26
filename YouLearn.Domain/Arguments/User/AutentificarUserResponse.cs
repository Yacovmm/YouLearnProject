using System;
using YouLearn.Domain.Entitties;

namespace YouLearn.Domain.Arguments.User
{
    public class AutentificarUserResponse
    {
        public Guid Id { get; set; }

        public  string FirstName { get; set; }

        public static explicit operator AutentificarUserResponse(Entitties.User entity)
        {
            return new AutentificarUserResponse()
            {
                Id = entity.Id,
                FirstName = entity.Nome.FirstName
            };
        }
    }
}
