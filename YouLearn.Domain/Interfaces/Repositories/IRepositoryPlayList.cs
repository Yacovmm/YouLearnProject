using System;
using System.Collections;
using System.Collections.Generic;
using YouLearn.Domain.Entitties;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayList
    {
        IEnumerable<Playlist> List(Guid userId);

        Playlist Obter(Guid playListId);

        Playlist AddPlayList(Playlist playlist);

        void DeletePlayList(Playlist playlist);
    }
}
