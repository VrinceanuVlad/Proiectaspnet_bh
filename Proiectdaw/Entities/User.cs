using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Entities
{
    public class User :IdentityUser<int>
    {
        public User() : base() { }
        public string FirstaName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
