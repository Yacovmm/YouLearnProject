using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Entitties;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObject;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServicePlayList : Notifiable, IServicePlayList
    {
        //Dependencies
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryPlayList _repositoryPlayList;

        public ServicePlayList(IRepositoryUser repositoryUser, IRepositoryPlayList repositoryPlayList)
        {
            _repositoryUser = repositoryUser;
            _repositoryPlayList = repositoryPlayList;
        }

        public PlayListResponse AddCanal(AddPlayListRequest request, Guid userId)
        {
            var user = _repositoryUser.Obter(userId);
            var playList = new Playlist(request.Name, user);

            AddNotifications(playList);

            if (this.IsInvalid())
                return null;

            _repositoryPlayList.AddPlayList(playList);

            return (PlayListResponse)playList;
        }

        public Response DeletePlayList(Guid CanalId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayListResponse> List(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
