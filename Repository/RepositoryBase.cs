using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }
    }
}