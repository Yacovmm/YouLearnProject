using System;
using System.Collections;
using System.Collections.Generic;
using prmToolkit.NotificationPattern;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Interfaces.Services.Base;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceCanal : IServiceBase
    {
        IEnumerable<CanalResponse> List(Guid userId);

        CanalResponse AddCanal(AddCanalRequest request, Guid userId);

        Response DeleteCanal(Guid canalId);
    }
}
