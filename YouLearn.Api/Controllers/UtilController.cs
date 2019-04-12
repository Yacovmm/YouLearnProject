using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YouLearn.Api.Controllers
{
    public class UtilController
    {
        [HttpGet]
        [Route("Version")]
        public object Version()
        {
            return new
            {
                Developer = "Yacov Rosenberg",
                Version = "0.0.1"
            };
        }


        [HttpPost]
        [Route("")]
        public object VersionPost(string a)
        {
            return new
            {
                Status = "Post"
            };
        }
    }
}
