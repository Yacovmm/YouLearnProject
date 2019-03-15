using System;
using YouLearn.Domain.Entitties;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser
    {
        User Obter(Guid id);

        User Obter(string email, string senha);

        void Save(User user);

        bool IsExist(string email);
    }
}
