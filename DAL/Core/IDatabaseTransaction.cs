using System;

namespace bARTSolution.Domain.Data.Core
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
