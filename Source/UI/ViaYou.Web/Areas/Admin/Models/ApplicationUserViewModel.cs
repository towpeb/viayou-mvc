using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViaYou.Domain.Users;
using ViaYou.Infraestructure.Mapping;

namespace ViaYou.Web.Areas.Admin.Models
{
    public class ApplicationUserViewModel:IMapFrom<ApplicationUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}