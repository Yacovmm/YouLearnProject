using YouLearn.Domain.ValueObject;

namespace YouLearn.Domain.Arguments.User
{
    public class AutentificarUserRequest
    {
        public Email Email { get; set; }

        public string Senha { get; set; }
    }
}
