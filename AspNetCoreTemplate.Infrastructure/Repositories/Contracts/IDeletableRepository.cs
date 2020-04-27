namespace AspNetCoreTemplate.Infrastructure.Repositories.Contracts
{
    using AspNetCoreTemplate.Infrastructure.Models.Common;
    
    using System.Linq;

    public interface IDeletableRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        void UnDelete(TEntity entity);

        void HardDelete(TEntity entity);
    }
}