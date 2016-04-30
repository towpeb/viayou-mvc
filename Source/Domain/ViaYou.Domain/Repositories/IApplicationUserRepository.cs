using System.Linq;
using ViaYou.Domain.Users;

namespace ViaYou.Domain.Repositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetById(string id);
        void Add(ApplicationUser user);
        IQueryable<ApplicationUser> GetAll();
        bool Add(ApplicationUser user, string password);
        void Delete(string id);
    }
}
