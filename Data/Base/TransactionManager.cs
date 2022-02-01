using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Base
{
    public class TransactionManager :ITransactionManager
    {
        public IDbContextTransaction BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new System.NotImplementedException();
        }
    }
}