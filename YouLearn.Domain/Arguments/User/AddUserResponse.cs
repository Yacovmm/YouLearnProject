using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.User
{
    public class AddUserResponse
    {
        public AddUserResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
