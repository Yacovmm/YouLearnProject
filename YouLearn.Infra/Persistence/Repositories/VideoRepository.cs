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
    public class VideoRepository : IRepositoryVideo
    {
        private readonly YouLearnContext _context;

        public VideoRepository(YouLearnContext context)
        {
            _context = context;
        }

        public void AddVideo(Video video)
        {
            _context.Videos.Add(video);
        }

        public bool ExisteCanalAssociado(Guid idCanal)
        {
            return _context.Videos.Any(x => x.Canal.Id == idCanal);
        }

        public bool ExistePlayListAssociado(Guid idPlaylist)
        {
            return _context.Videos.Any(x => x.Playlist.Id == idPlaylist);
        }

        public IEnumerable<Video> ListVideos(string tags)
        {
            var query = _context.Videos.Include(x => x.Canal).Include(x => x.Playlist).AsQueryable();

            tags.Split(' ').ToList().ForEach(tag =>
            {
                query = query.Where(x => x.Tags.Contains(tag) || x.Titulo.Contains(tag) || x.Descricao.Contains(tag));
            });

            return query.ToList();
        }

        public IEnumerable<Video> ListVideos(Guid idPlaylist)
        {
            return  _context.Videos.Include(x => x.Canal).Include(x => x.Playlist)
                .Where(x => x.Playlist.Id == idPlaylist).ToList();
        }
    }
}
