using ApiProduto.Dto.Produto.Request;

namespace ApiProduto.Services.Produto.Interfaces
{
    public interface IProdutoService
    {
        Task<IResult> GetByIdAsync(int id);
        Task<IResult> GetAllAsync(GetAllProdutoRequest request);
        Task<IResult> AddAsync(AddProdutoRequest request);
        Task<IResult> UpdateAsync(int id, UpdateProdutoRequest request);
        Task<IResult> RemoveAsync(int id);
    }
}
