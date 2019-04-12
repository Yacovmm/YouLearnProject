using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using YouLearn.Domain.Entitties;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class UserRepository : IRepositoryUser
    {
        private readonly YouLearnContext _context;

        public UserRepository(YouLearnContext context)
        {
            _context = context;
        }

        public User Obter(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Obter(string email, string senha)
        {
            return _context.Users.FirstOrDefault(x => x.Email.Endereco == email && x.Senha == senha);
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
        }

        public bool IsExist(string email)
        {
            return _context.Users.Any(x => x.Email.Endereco.Equals(email));
        }
    }
}
