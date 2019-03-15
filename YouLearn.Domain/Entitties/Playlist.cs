using YouLearn.Domain.Entitties.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entitties
{
    public class Playlist : EntityBase
    {
        public User User { get; set; }

        public EnumStatus Status { get; set; }

    }
}
