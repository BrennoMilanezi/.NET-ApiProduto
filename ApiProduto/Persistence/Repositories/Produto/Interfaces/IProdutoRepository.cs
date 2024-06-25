using ApiProduto.Dto.Produto.Request;
using ApiProduto.Persistence.Repositories.Base.Interfaces;

namespace ApiProduto.Persistence.Repositories.Produto.Interfaces
{
    public interface IProdutoRepository : IBaseRepository<Entities.Produto>
    {
        Task<Entities.Produto> GetByIdAsync(int id);
        Task<IList<Entities.Produto>> GetAllAsync(GetAllProdutoRequest request);
    }
}
