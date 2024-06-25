namespace ApiProduto.Entities;

public class Produto
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public bool Ativo { get; set; }
    public DateTime? DataFabricacao { get; set; }
    public DateTime? DataValidade { get; set; }
    public string CodigoFornecedor { get; set; }
    public string DescricaoFornecedor { get; set; }
    public string CnpjFornecedor { get; set; }

    private Produto() { }

    public static Produto Builder(string descricao, DateTime? dataFabricacao, 
                            DateTime? dataValidade, string codigoFornecedor, 
                            string descricaoFornecedor, string cnpjFornecedor)
    {
        return new Produto
        {
            Descricao = descricao,
            Ativo = true,
            DataFabricacao = dataFabricacao,
            DataValidade = dataValidade,
            CodigoFornecedor = codigoFornecedor,
            DescricaoFornecedor = descricaoFornecedor,
            CnpjFornecedor = cnpjFornecedor
        };
    }
}

