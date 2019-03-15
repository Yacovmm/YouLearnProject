using System;

namespace YouLearn.Domain.Entitties.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();              
        }

        public virtual Guid Id { get; set; }
    }
}
