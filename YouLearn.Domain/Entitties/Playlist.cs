using YouLearn.Domain.Entitties.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entitties
{
    public class Playlist : EntityBase
    {
        public string Nome { get; private set; }

        public User User { get; private set; }

        public EnumStatus Status { get; private set; }

    }
}
