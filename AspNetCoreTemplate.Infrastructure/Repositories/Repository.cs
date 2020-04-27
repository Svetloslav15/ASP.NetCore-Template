namespace AspNetCoreTemplate.Infrastructure.Repositories
{
    using AspNetCoreTemplate.Infrastructure.Repositories.Contracts;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using System.Linq;
    using System.Threading.Tasks;

    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected ApplicationDbContext DbContext { get; set; }

        protected DbSet<TEntity> DbSet { get; set; }

        public Repository(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.DbSet = this.DbContext.Set<TEntity>();
        }

        public virtual Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public virtual Task<int> SaveChangesAsync() => this.DbContext.SaveChangesAsync();

        public virtual void Update(TEntity entity)
        {
            EntityEntry<TEntity> data = this.DbContext.Entry(entity);
            
            if (data != entity)
            {
                this.DbSet.Attach(entity);
            }

            data.State = EntityState.Modified;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.DbContext?.Dispose();
            }
        }
    }
}