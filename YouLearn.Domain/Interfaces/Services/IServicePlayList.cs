using System;
using System.Collections;
using System.Collections.Generic;
using prmToolkit.NotificationPattern;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.PlayList;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Interfaces.Services.Base;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServicePlayList : IServiceBase
    {
        IEnumerable<PlayListResponse> List(Guid userId);

        PlayListResponse AddPlayList(AddPlayListRequest request, Guid userId);

        Response DeletePlayList(Guid CanalId);
    }
}
