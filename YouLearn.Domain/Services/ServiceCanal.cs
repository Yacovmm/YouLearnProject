using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Response DeleteCanal(Guid CanalId)
        {
            throw new NotImplementedException();
        }
    }
}
