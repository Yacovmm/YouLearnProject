using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entitties;

namespace YouLearn.Domain.Arguments.PlayList
{
    public class PlayListResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static explicit operator PlayListResponse(Entitties.Playlist v)
        {
            return new PlayListResponse
            {
                Id = v.Id,
                Name = v.Nome
            };
        }
    }
}
