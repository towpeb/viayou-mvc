using System.Data.Entity.Validation;
using ViaYou.Data.Repositories;
using ViaYou.Domain.Repositories;

namespace ViaYou.Data
{
    public class TransactionManager : BaseRepository, ITransactionManager
    {
        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //TODO: improve this
                throw new DbEntityValidationException(ex.Message);
            }
        }
    }
}