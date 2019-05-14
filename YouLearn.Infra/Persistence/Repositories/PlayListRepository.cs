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
    public class PlayListRepository : IRepositoryPlayList
    {
        private readonly YouLearnContext _context;

        public PlayListRepository(YouLearnContext context)
        {
            _context = context;
        }


        public Playlist AddPlayList(Playlist playList)
        {
            _context.Playlists.Add(playList);
            return playList;
        }

        public IEnumerable<Playlist> ListCanais(Guid userId)
        {
            return _context.PlayLists.Where(x => x.Id == userId).AsNoTracking().ToList();
        }

        public PlayList Obter(Guid playListId)
        {
            return _context.PlayLists.FirstOrDefault(x => x.Id == playListId);
        }

        public void DeletePlayList(PlayList playList)
        {
            _context.PlayLists.Remove(playList);
        }
    }
}
