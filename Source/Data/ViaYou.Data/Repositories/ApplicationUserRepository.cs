using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Users;

namespace ViaYou.Data.Repositories
{
    public class ApplicationUserRepository: BaseRepository,IApplicationUserRepository
    {

        public void Add(ApplicationUser user)
        {
            Context.Users.Add(user);
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return Context.Users;
        }

        public ApplicationUser GetById(string id)
        {
            return Context.Users.Find(id);
        }

        public bool Add(ApplicationUser user, string password)
        {
            return true;
        }

    }
}
