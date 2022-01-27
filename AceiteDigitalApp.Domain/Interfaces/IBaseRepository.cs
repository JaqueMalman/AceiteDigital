using AceiteDigitalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceiteDigitalApp.Domain.Interfaces
{
    public interface IBaseRepository<T> 
    {
        void Add<TEntity>(TEntity entity) where TEntity : T;

        void Update<TEntity>(TEntity entity) where TEntity : T;

        void Delete<TEntity>(TEntity entity) where TEntity : T;

        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(long id);
    }
}
