using System;
using System.Collections;
using System.Collections.Generic;
using YouLearn.Domain.Entitties;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryVideo
    {
        void AddVideo(Video video);

        IEnumerable<Video> ListVideos(string tags);

        IEnumerable<Video> ListVideos(Guid idPlaylist);

        bool ExisteCanalAssociado(Guid idCanal);

        bool ExistePlayListAssociado(Guid idPlaylist);

    }
}
