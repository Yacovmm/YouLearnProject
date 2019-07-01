using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Video
{
    public class AdicionarVideoResponse
    {
        private Guid id;

        public AdicionarVideoResponse(Guid id)
        {
            this.id = id;
        }

        public Guid IdVideo { get; set; }
    }
}
