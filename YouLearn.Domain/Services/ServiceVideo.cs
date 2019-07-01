using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Entitties;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObject;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServiceVideo : Notifiable, IServiceVideo
    {
        //Dependencies
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryVideo _repositoryVideo;
        private readonly IRepositoryCanal _repositoryCanal;
        private readonly IRepositoryPlayList _repositoryPlayList;

        public ServiceVideo(IRepositoryUser repositoryUser, IRepositoryVideo repositoryVideo, IRepositoryCanal repositoryCanal, IRepositoryPlayList repositoryPlayList)
        {
            _repositoryUser = repositoryUser;
            _repositoryVideo = repositoryVideo;
            _repositoryCanal = repositoryCanal;
            _repositoryPlayList = repositoryPlayList;
        }

        public AdicionarVideoResponse AdicionarVideo(AdicionarVideoRequest request, Guid idUser)
        {
            if(request == null)
            {
                AddNotification("AdicionarVideoRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarVideoRequest"));
                return null;
            }

            var user = _repositoryUser.Obter(idUser);
            if(user == null)
            {
                AddNotification("User", MSG.X0_NAO_INFORMADO.ToFormat("Usuário"));
                return null;
            }

            var canal = _repositoryCanal.Obter(request.IdCanal);
            if(canal == null)
            {
                AddNotification("Canal", MSG.X0_NAO_INFORMADO.ToFormat("Canal"));
                return null;
            }

            Playlist playList = null;
            if(request.IdPlayList != Guid.Empty)
            {
                playList = _repositoryPlayList.Obter(request.IdPlayList);
                if(playList == null)
                {
                    AddNotification("PlayList", MSG.X0_NAO_INFORMADA.ToFormat("PlayList"));
                    return null;
                }
            }

            var video = new Video(canal, playList, request.Titulo, request.Descricao, request.Tags, request.OrdemNaPlayList, request.IdVideoYouTube, user);

            AddNotifications(video);

            if (this.IsInvalid())
                return null;

            _repositoryVideo.AddVideo(video);

            return new AdicionarVideoResponse(video.Id);

        }

        public IEnumerable<VideoResponse> List(string tags)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.ListVideos(tags);

            var response = videoCollection.ToList().Select(entity => (VideoResponse)entity);

            return response;
        }

        public IEnumerable<VideoResponse> List(Guid idPlayList)
        {
            IEnumerable<Video> videoCollection = _repositoryVideo.ListVideos(idPlayList);

            var response = videoCollection.ToList().Select(entity => (VideoResponse)entity);
            return response;
        }
    }
}
