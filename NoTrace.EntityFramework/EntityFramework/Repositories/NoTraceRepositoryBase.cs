using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace NoTrace.EntityFramework.Repositories
{
    public abstract class NoTraceRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<NoTraceDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected NoTraceRepositoryBase(IDbContextProvider<NoTraceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class NoTraceRepositoryBase<TEntity> : NoTraceRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected NoTraceRepositoryBase(IDbContextProvider<NoTraceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
