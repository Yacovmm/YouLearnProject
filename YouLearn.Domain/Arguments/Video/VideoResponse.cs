using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entitties;

namespace YouLearn.Domain.Arguments.Video
{
    public class VideoResponse
    {
        public string NomeCanal { get; set; }

        public Guid? IdPlayList { get; set; }

        public string NomePlayList { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Thumbnail { get; set; }

        public string IdVideoYouTube { get; set; }

        public int OrdemNaPlayList { get; set; }

        public string Url { get; set; }

        public static explicit operator VideoResponse(Entitties.Video entity)
        {
            return new VideoResponse()
            {
                NomeCanal = entity.Canal.Nome,
                IdPlayList = entity.Playlist?.Id,
                NomePlayList = entity.Playlist?.Nome,
                Titulo = entity.Titulo,
                Descricao = entity.Descricao,
                Thumbnail = string.Concat("https://img.youtube.com/vi/", entity.IdVideoNoYouTube, "/mqdefault.jpg"),
                IdVideoYouTube = entity.IdVideoNoYouTube,
                OrdemNaPlayList = entity.OrdemNaPlaylist,
                Url = string.Concat("https://www.youtube.com/embed/", entity.IdVideoNoYouTube)
            };
        }
    }
}   
