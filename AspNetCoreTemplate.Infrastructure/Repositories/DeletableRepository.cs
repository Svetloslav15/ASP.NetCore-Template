namespace AspNetCoreTemplate.Infrastructure.Repositories
{
    using AspNetCoreTemplate.Infrastructure.Models.Common;
    using AspNetCoreTemplate.Infrastructure.Repositories.Contracts;
    using System;
    using System.Linq;

    public class DeletableRepository<TEntity> : Repository<TEntity>, IDeletableRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        public DeletableRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public override IQueryable<TEntity> All() => base.All().Where(x => x.IsDeleted == false);

        public override void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
            base.Update(entity);
        }

        public IQueryable<TEntity> AllWithDeleted() => base.All();

        public void HardDelete(TEntity entity) => base.Delete(entity);

        public void UnDelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = DateTime.UtcNow;
            base.Update(entity);
        }
    }
}
