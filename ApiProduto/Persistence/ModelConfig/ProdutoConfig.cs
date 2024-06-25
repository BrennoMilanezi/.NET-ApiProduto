using ApiProduto.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiProduto.Persistence.ModelConfig;

public class ProdutoConfig : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(x => x.Codigo);

        builder.Property(x => x.Codigo).IsRequired().HasColumnName("CD_PRODUTO").HasColumnType("INT");
        builder.Property(x => x.Descricao).IsRequired().HasColumnName("TX_DESCRICAO").HasColumnType("VARCHAR(500)");
        builder.Property(x => x.Ativo).HasColumnName("BL_ATIVO").HasColumnType("BIT");
        builder.Property(x => x.DataFabricacao).HasColumnName("DT_FABRICACAO");
        builder.Property(x => x.DataValidade).HasColumnName("DT_VALIDADE");
        builder.Property(x => x.CodigoFornecedor).HasColumnName("CD_FORNECEDOR").HasColumnType("VARCHAR(500)");
        builder.Property(x => x.DescricaoFornecedor).HasColumnName("TX_DESCRICAO_FORNECEDOR").HasColumnType("VARCHAR(500)");
        builder.Property(x => x.CnpjFornecedor).HasColumnName("TX_CNPJ_FORNECEDOR").HasColumnType("VARCHAR(500)");
    }
}

