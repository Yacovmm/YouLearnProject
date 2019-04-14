using System;
using System.Collections;
using System.Collections.Generic;
using YouLearn.Domain.Entitties;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryCanal
    {
        IEnumerable<Canal> ListCanais(Guid userId);

        Canal Obter(Guid canalId);

        Canal AddCanal(Canal canal);

        void DeleteCanal(Canal canal);
    }
}
