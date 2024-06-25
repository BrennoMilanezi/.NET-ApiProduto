using ApiProduto.Persistence.Repositories.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiProduto.Persistence.Repositories.Base
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        protected readonly DbContext dbContext;

        public BaseRepository(DbContext context)
        {
            dbContext = context;
        }

        public virtual async Task<bool> AddAsync(TModel entity)
        {
            await dbContext.Set<TModel>().AddAsync(entity);

            var returnValue = await dbContext.SaveChangesAsync();
            return returnValue > 0;
        }

        public async Task<bool> UpdateAsync(TModel entity)
        {
            dbContext.Set<TModel>().Update(entity);
            var returnValue = await dbContext.SaveChangesAsync();
            return returnValue > 0;
        }
    }
}