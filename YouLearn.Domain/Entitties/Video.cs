using YouLearn.Domain.Entitties.Base;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entitties
{
    public class Video : EntityBase
    {
        public Canal Canal { get; set; }

        public Playlist Playlist { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Tags { get; set; }

        public int OrdemNaPlaylist { get; set; }

        public string IdVideoNoYouTube { get; set; }

        public User UsuarioSugeriu { get; set; }

        public EnumStatus Status { get; set; }


    }
}
