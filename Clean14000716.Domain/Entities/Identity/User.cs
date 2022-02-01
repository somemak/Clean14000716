using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Clean14000716.Domain.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string FatherName { get; set; }
    }
}