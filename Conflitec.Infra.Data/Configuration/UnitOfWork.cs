using Conflitec.Domain.Interfaces.Infra.Data;
using Conflitec.Infra.Data.Context;

namespace Conflitec.Infra.Data.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ConflitecDB _dbContext;

        public UnitOfWork(ConflitecDB dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Commit()
        {
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public void Close()
        {
            Dispose();
        }

        public string GetContextId()
        {
            return _dbContext.GetHashCode().ToString();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}
