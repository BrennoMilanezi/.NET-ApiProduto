using ApiProduto.Dto.Produto.Request;
using ApiProduto.Services.Produto.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduto.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetByIdAsync(int id)
        {
            var response = await _produtoService.GetByIdAsync(id);
            return response;
        }

        [HttpGet("")]
        public async Task<IResult> GetAllAsync(GetAllProdutoRequest request)
        {
            var response = await _produtoService.GetAllAsync(request);
            return response;
        }

        [HttpPost("")]
        public async Task<IResult> AddAsync([FromBody] AddProdutoRequest request)
        {
            var response = await _produtoService.AddAsync(request);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateAsync(int id, [FromBody] UpdateProdutoRequest request)
        {
            var response = await _produtoService.UpdateAsync(id, request);
            return response;
        }

        [HttpPut("remover/{id}")]
        public async Task<IResult> RemoveAsync(int id)
        {
            var response = await _produtoService.RemoveAsync(id);
            return response;
        }
    }
}