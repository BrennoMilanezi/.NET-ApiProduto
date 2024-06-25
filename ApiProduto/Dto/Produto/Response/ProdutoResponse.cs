namespace ApiProduto.Dto.Produto.Response
{
    public class ProdutoResponse
    {
        public int Codigo{ get; set; }
        public string Descricao { get; set; }
        public string Ativo { get; set; }
        public string DataFabricacao { get; set; }
        public string DataValidade { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
    }
}
