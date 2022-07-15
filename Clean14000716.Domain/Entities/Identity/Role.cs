using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;

namespace Clean14000716.Domain.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }

    }
}