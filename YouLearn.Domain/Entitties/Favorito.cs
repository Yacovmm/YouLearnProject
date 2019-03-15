using YouLearn.Domain.Entitties.Base;

namespace YouLearn.Domain.Entitties
{
    public class Favorito : EntityBase
    {
        public Video Video { get; set; }

        public User User { get; set; }
    }
}
