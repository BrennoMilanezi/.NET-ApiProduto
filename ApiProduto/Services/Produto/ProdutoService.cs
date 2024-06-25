using ApiProduto.Dto.Produto.Request;
using ApiProduto.Dto.Produto.Response;
using ApiProduto.Persistence.Repositories.Produto.Interfaces;
using ApiProduto.Services.Produto.Interfaces;
using AutoMapper;

namespace ApiProduto.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;


        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IResult> GetByIdAsync(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id);

                if (produto == null)
                    return Results.BadRequest(error: "Produto não encontrado");

                var produtoResponse = _mapper.Map<ProdutoResponse>(produto);

                return Results.Ok(produtoResponse);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(error: ex.Message);
            }
        }

        public async Task<IResult> GetAllAsync(GetAllProdutoRequest request)
        {
            try
            {
                var produtos = await _produtoRepository.GetAllAsync(request);

                var produtoResponse = _mapper.Map<IList<ProdutoResponse>>(produtos);

                return Results.Ok(produtoResponse);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(error: ex.Message);
            }
        }

        public async Task<IResult> AddAsync(AddProdutoRequest request)
        {
            try
            {
                if (request.DataFabricacao.HasValue && request.DataValidade.HasValue && request.DataFabricacao >= request.DataValidade)
                    return Results.BadRequest(error: "Data de fabricação não pode ser maior ou igual a data de validade.");
                
                var produto = Entities.Produto.Builder(request.Descricao, request.DataFabricacao, 
                                            request.DataValidade, request.CodigoFornecedor, 
                                            request.DescricaoFornecedor, request.CnpjFornecedor);

                return Results.Ok(await _produtoRepository.AddAsync(produto));
            }
            catch (Exception ex)
            {
                return Results.BadRequest(error: ex.Message);
            }
        }

        public async Task<IResult> UpdateAsync(int id, UpdateProdutoRequest request)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id);

                if (produto == null)
                    return Results.BadRequest(error: "Produto não encontrado");

                if (request.DataFabricacao.HasValue && request.DataValidade.HasValue && request.DataFabricacao >= request.DataValidade)
                    return Results.BadRequest(error: "Data de fabricação não pode ser maior ou igual a data de validade.");
                
                produto.Descricao = request.Descricao;
                produto.DataValidade = request.DataValidade;
                produto.DataFabricacao = request.DataFabricacao;
                produto.DescricaoFornecedor = request.DescricaoFornecedor;
                produto.CodigoFornecedor = request.CodigoFornecedor;
                produto.CnpjFornecedor = request.CnpjFornecedor;

                return Results.Ok(await _produtoRepository.UpdateAsync(produto));
            }
            catch (Exception ex)
            {
                return Results.BadRequest(error: ex.Message);
            }
        }

        public async Task<IResult> RemoveAsync(int id)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(id);

                if (produto == null)
                    return Results.BadRequest(error: "Produto não encontrado");
                
                produto.Ativo = false;

                return Results.Ok(await _produtoRepository.UpdateAsync(produto));
            }
            catch (Exception ex)
            {
                return Results.BadRequest(error: ex.Message);
            }
        }
    }
}
