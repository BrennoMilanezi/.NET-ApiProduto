using ApiProduto.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using ApiProduto.Entities;
using ApiProduto.Persistence.Repositories.Produto.Interfaces;
using ApiProduto.Dto.Produto.Request;
using ApiProduto.Persistence.Repositories.Base;

namespace ApiProduto.Persistence.Repositories.Produto
{
    public class ProdutoRepository : BaseRepository<Entities.Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Entities.Produto> GetByIdAsync(int id)
        {
            return await dbContext.Set<Entities.Produto>().AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == id);
        }

        public async Task<IList<Entities.Produto>> GetAllAsync(GetAllProdutoRequest request)
        {
            bool ativo = request.Ativo ?? true;
            IQueryable<Entities.Produto> query = dbContext.Set<Entities.Produto>().AsNoTracking().Where(x => x.Ativo == ativo).AsQueryable();

            if (!string.IsNullOrEmpty(request.TermoBusca))
            {
                query = query.Where(x => x.Descricao.Contains(request.TermoBusca)
                                        || x.CodigoFornecedor.Contains(request.TermoBusca)
                                        || x.DescricaoFornecedor.Contains(request.TermoBusca)
                                        || x.CnpjFornecedor.Contains(request.TermoBusca));
            }

            if (request.DataInicioValidade.HasValue && request.DataFimValidade.HasValue)
            {
                query = query.Where(x => x.DataValidade.HasValue
                                    && x.DataValidade.Value.Date >= request.DataInicioValidade.Value.Date
                                    && x.DataValidade.Value.Date <= request.DataFimValidade.Value.Date);
            }

            if (request.DataInicioFabricacao.HasValue && request.DataFimFabricacao.HasValue)
            {
                query = query.Where(x => x.DataFabricacao.HasValue
                                    && x.DataFabricacao.Value.Date >= request.DataInicioFabricacao.Value.Date
                                    && x.DataFabricacao.Value.Date <= request.DataFimFabricacao.Value.Date);
            }

            int page = request.Page ?? 1;
            int pageSize = request.PageSize ?? 10;

            return await query.Skip((page - 1)* pageSize).Take(pageSize).ToListAsync();
        }
    }
}
