using System.Data.Entity.Validation;
using Microsoft.Practices.Unity;

namespace ViaYou.Data.Repositories
{
    public class BaseRepository
    {
        [Dependency]
        public ViaYouDataContext Context { get; set; }

        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

            }
        }
    }
}
