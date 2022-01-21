using AceiteDigital.Data.Context;
using AceiteDigitalApp.Domain.Entities;
using AceiteDigitalApp.Domain.Interfaces;

namespace AceiteDigital.Data.Repository
{
    public class BaseRepository<TEntity> : 
        IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity obj)
        {
            _applicationDbContext.Set<TEntity>().Add(obj);
            _applicationDbContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _applicationDbContext.Set<TEntity>().ToList();

        public TEntity Select(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}