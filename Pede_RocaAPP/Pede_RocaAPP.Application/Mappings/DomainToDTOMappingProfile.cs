using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() 
        { 
            // adicionar todas as categorias
            CreateMap<Avaliacao, AvaliacaoDTO>().ReverseMap();
            CreateMap<CarrinhoCompra, CarrinhoCompraDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Mensagem, MensagemDTO>().ReverseMap();
            CreateMap<PlanoAssinatura, PlanoAssinaturaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<ProdutoFavorito, ProdutoFavoritoDTO>().ReverseMap();
            CreateMap<ProdutosPedido, ProdutosPedidoDTO>().ReverseMap();
            CreateMap<UnidadeMedida, UnidadeMedidaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

        }
    }
}
