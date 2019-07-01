using System;
using System.Collections;
using System.Collections.Generic;
using prmToolkit.NotificationPattern;
using YouLearn.Domain.Arguments.Canal;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Interfaces.Services.Base;
using Response = YouLearn.Domain.Arguments.Base.Response;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceVideo : IServiceBase
    {
        AdicionarVideoResponse AdicionarVideo(AdicionarVideoRequest request, Guid idUser);

        IEnumerable<VideoResponse> List(string tags);

        IEnumerable<VideoResponse> List(Guid idPlayList);
    }
}
