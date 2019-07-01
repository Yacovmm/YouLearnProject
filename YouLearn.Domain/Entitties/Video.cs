using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Entitties.Base;
using YouLearn.Domain.Enums;
using YouLearn.Domain.Resources;

namespace YouLearn.Domain.Entitties
{
    public class Video : EntityBase
    {
        
        public Video(Canal canal, Playlist playlist, string titulo, string descricao, string tags, int? ordemNaPlaylist, string idVideoNoYouTube, User usuarioSugeriu)
        {
            Canal = canal;
            Playlist = playlist;
            Titulo = titulo;
            Descricao = descricao;
            Tags = tags;
            OrdemNaPlaylist = ordemNaPlaylist;
            IdVideoNoYouTube = idVideoNoYouTube;
            UsuarioSugeriu = usuarioSugeriu;
            Status = EnumStatus.EmAnalise;

            new AddNotifications<Video>(this)
                .IfNullOrEmptyOrInvalidLength(x => x.Titulo, 1, 200, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Titulo", "1", "200"))
                .IfNullOrEmptyOrInvalidLength(x => x.Descricao, 1, 255, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descroção", "1", "255"))
                .IfNullOrEmptyOrInvalidLength(x => x.Tags, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Tag", "1", "50"))
                .IfNullOrEmptyOrInvalidLength(x => x.IdVideoNoYouTube, 1, 50, MSG.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("IdVideoYoutube", "1", "50"));

            AddNotifications(Canal);

            if (playlist != null)
                AddNotifications(playlist);

        }

        public Canal Canal { get; private set; }

        public Playlist Playlist { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public string Tags { get; private set; }

        public int OrdemNaPlaylist { get; private set; }

        public string IdVideoNoYouTube { get; private set; }

        public User UsuarioSugeriu { get; private set; }

        public EnumStatus Status { get; private set; }


    }
}
