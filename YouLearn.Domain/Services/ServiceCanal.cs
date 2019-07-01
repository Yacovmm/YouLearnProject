using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Entitties;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Resources;
using YouLearn.Domain.ValueObject;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Services
{
    public class ServiceCanal : Notifiable, IServiceCanal
    {
        //Dependencies
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryCanal _repositoryCanal;


        public ServiceCanal(IRepositoryUser repositoryUser, IRepositoryCanal repositoryCanal)
        {
            _repositoryUser = repositoryUser;
            _repositoryCanal = repositoryCanal;
        }


        public CanalResponse AddCanal(AddCanalRequest request, Guid userId)
        {
            var user = _repositoryUser.Obter(userId);
            var canal = new Canal(request.Name, request.UrlLogo, user);

            AddNotifications(canal);

            if (this.IsInvalid())
                return null;

            _repositoryCanal.AddCanal(canal);

            return (CanalResponse)canal;
        }

        public IEnumerable<CanalResponse> List(Guid userId)
        {
            var canalCollection = _repositoryCanal.ListCanais(userId);

            var response = canalCollection.ToList().Select(x => (CanalResponse)x);

            return response;
        }

        public Response DeleteCanal(Guid canalId)
        {
            //bool existe = _repositoryVideo.ExisteCanalAssociado(canalId);

            bool existe = true;
            if (existe)
            {
                AddNotification("Canal", MSG.NAO_E_POSSIVEL_EXCLUIR_UM_X0_ASSOCIADO_A_UM_X1.ToFormat("Canal", "video"));
                return null;
            }

            var canal = _repositoryCanal.Obter(canalId);

            if (canal == null)
            {
                AddNotification("Canal", MSG.DADOS_NAO_ENCONTRADOS);
            }

            if (this.IsInvalid())
                return null;

            _repositoryCanal.DeleteCanal(canal);

            return new Response() { Messagem = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }
    }
}
