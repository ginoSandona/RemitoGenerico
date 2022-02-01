using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Base
{
    public interface ITransactionManager
    {
        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}