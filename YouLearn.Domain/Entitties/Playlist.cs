using prmToolkit.NotificationPattern;
using YouLearn.Domain.Entitties.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entitties
{
    public class Playlist : EntityBase
    {
        public Playlist(string nome, User user)
        {
            Nome = nome;
            User = user;

            new AddNotifications<Playlist>(this).IfNullOrInvalidLength(x => x.Nome, 2, 100);
        }

        public string Nome { get; private set; }

        public User User { get; private set; }

        public EnumStatus Status { get; private set; }

    }
}
