using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M151_WebShop.Models
{
    public class RoleManagerViewModel
    {
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<CustomRole> Roles { get; set; }
    }
}