using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ViaYou.Domain.Users;

namespace ViaYou.Data
{
    public class IdentityManager
    {
        public IdentityManager()
        {
            Context = new ViaYouDataContext();
        }

        public IdentityManager(ViaYouDataContext context)
        {
            Context = context;
        }

        protected ViaYouDataContext Context { get; set; }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ViaYouDataContext()));
            return rm.RoleExists(name);
        }

        public bool CreateRole(string name)
        {
            //var context = new PhylDataContext();
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(Context));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }

        public bool CreateUser(ApplicationUser user, string password)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(Context));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(Context));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(Context));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userId, role.RoleId);
            }
        }

        public IEnumerable<string> GetAllRoles(string userId = null)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(Context));

            if (userId == null)
                return Context.Roles.Select(x => x.Name);

            var user = Context.Users.Find(userId);
            if (user == null)
                throw new Exception(String.Format("No user was found with the id '{0}'", userId));

            return um.GetRolesAsync(userId).Result;
        }

    }
}
