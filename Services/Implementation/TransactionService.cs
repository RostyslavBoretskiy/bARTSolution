using bARTSolution.Domain.Data.Core;

namespace bARTSolution.Domain.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly IDatabaseTransaction databaseTransaction;

        public TransactionService(IDatabaseTransaction databaseTransaction)
        {
            this.databaseTransaction = databaseTransaction;
        }

        public void Begin()
        {
            databaseTransaction.Begin();
        }

        public void Commit()
        {
            databaseTransaction.Commit();
        }

        public void Dispose()
        {
            databaseTransaction.Dispose();
        }

        public void Rollback()
        {
            databaseTransaction.Rollback();
        }
    }
}
