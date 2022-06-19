using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using M151_WebShop.Common;
using M151_WebShop.Data;

namespace M151_WebShop.Data.ViewModel
{
    public class RoleManagerViewModel
    {
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<CustomRole> Roles { get; set; }
    }
}