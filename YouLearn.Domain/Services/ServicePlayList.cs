using System;
using System.Collections.Generic;
using System.Linq;
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

        public PlayListResponse AddPlayList(AddPlayListRequest request, Guid userId)
        {
            var user = _repositoryUser.Obter(userId);
            var playList = new Playlist(request.Name, user);

            AddNotifications(playList);

            if (this.IsInvalid())
                return null;

            _repositoryPlayList.AddPlayList(playList);

            return (PlayListResponse)playList;
        }

        public Response DeletePlayList(Guid playListId)
        {
            //bool existe _repositoryVideo.ExistePlayListAssociada(playListId);
            bool existe = false;

            if (existe)
            {
                AddNotification("PlayList", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("PlayList", "video"));
                return null;
            }

            Playlist playlist = _repositoryPlayList.Obter(playListId);

            if(playlist == null)
            {
                AddNotification("PlayList", MSG.DADOS_NAO_ENCONTRADOS);
            }

            if (this.IsInvalid())
                return null;

            _repositoryPlayList.DeletePlayList(playlist);

            return new Response() { Messagem = MSG.OPERACAO_REALIZADA_COM_SUCESSO };

        }

        public IEnumerable<PlayListResponse> List(Guid userId)
        {
            var playListCollection = _repositoryPlayList.List(userId);

            var response = playListCollection.ToList().Select(x => (PlayListResponse)x);

            return response;
        }
    }
}
