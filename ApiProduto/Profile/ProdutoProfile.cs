using ApiProduto.Dto.Produto.Response;

namespace ApiProduto.Profile
{
    public class ProdutoProfile : AutoMapper.Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Entities.Produto, ProdutoResponse>()
            .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo ? "Sim" : "Não"))
            .ForMember(dest => dest.DataFabricacao, opt => opt.MapFrom(src => src.DataFabricacao.HasValue ? src.DataFabricacao.Value.ToString("dd/MM/yyyy HH:mm") : ""))
            .ForMember(dest => dest.DataValidade, opt => opt.MapFrom(src => src.DataValidade.HasValue ? src.DataValidade.Value.ToString("dd/MM/yyyy HH:mm") : ""))
            .ForMember(dest => dest.CodigoFornecedor, opt => opt.MapFrom(src => src.CodigoFornecedor))
            .ForMember(dest => dest.DescricaoFornecedor, opt => opt.MapFrom(src => src.DescricaoFornecedor))
            .ForMember(dest => dest.CnpjFornecedor, opt => opt.MapFrom(src => src.CnpjFornecedor));
        }
        
    }
}
