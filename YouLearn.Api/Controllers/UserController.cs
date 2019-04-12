using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YouLearn.Domain.Arguments.User;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Infra.Transaction;

namespace YouLearn.Api.Controllers
{
    public class UserController : Base.ControllerBase
    {

        private readonly IServiceUser _serviceUser;

        public UserController(IUnitOfWork unitOfWork, IServiceUser serviceUser) : base(unitOfWork)
        {
            serviceUser = _serviceUser;
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("api/v1/User/New")]
        public async Task<IActionResult> New([FromBody] AddUserRequest request)
        {
            try
            {
                var response = _serviceUser.AddUser(request);
                return await ResponseAsync(response, _serviceUser);
            }
            catch (Exception e)
            {
                return await ResponseExceptionAsync(e);
            }
        }

    }
}
