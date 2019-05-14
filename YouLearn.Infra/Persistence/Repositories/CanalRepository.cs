using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using YouLearn.Domain.Entitties;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Infra.Persistence.EF;

namespace YouLearn.Infra.Persistence.Repositories
{
    public class CanalRepository : IRepositoryCanal
    {
        private readonly YouLearnContext _context;

        public CanalRepository(YouLearnContext context)
        {
            _context = context;
        }


        public Canal AddCanal(Canal canal)
        {
            _context.Canals.Add(canal);
            return canal;
        }

        public IEnumerable<Canal> ListCanais(Guid userId)
        {
            return _context.Canals.Where(x => x.Id == userId).AsNoTracking().ToList();
        }

        public Canal Obter(Guid canalId)
        {
            return _context.Canals.FirstOrDefault(x => x.Id == canalId);
        }

        public void DeleteCanal(Canal canal)
        {
            _context.Canals.Remove(canal);
        }
    }
}
