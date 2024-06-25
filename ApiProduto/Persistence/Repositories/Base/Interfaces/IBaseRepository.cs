namespace ApiProduto.Persistence.Repositories.Base.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        Task<bool> AddAsync(TModel entity);
        Task<bool> UpdateAsync(TModel entity);
    }
}
