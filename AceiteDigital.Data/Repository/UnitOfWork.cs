using AceiteDigital.Data.Context;
using AceiteDigitalApp.Domain.Interfaces;

namespace AceiteDigital.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        { 
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> CommitAsync()
        {
            var result = await _applicationDbContext.SaveChangesAsync();

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();    

            var type = typeof(TEntity);

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<TEntity>)_repositories[type];
            }

            _repositories[type] = new BaseRepository<TEntity>(_applicationDbContext);

            return (IBaseRepository<TEntity>)_repositories[type];
        }
    }
}
