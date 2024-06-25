namespace ApiProduto.Dto.Produto.Request
{
    public class GetAllProdutoRequest
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string TermoBusca { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataInicioFabricacao { get; set; }
        public DateTime? DataFimFabricacao { get; set; }
        public DateTime? DataInicioValidade { get; set; }
        public DateTime? DataFimValidade { get; set; }
    }
}