using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceUser : IServiceBase
    {
        AddUserResponse AddUser(AddUserRequest request);

        AutentificarUserResponse AutentificarUser(AutentificarUserRequest request);
    }
}
