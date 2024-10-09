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
            CreateMap<Avaliacao, AvaliacaoCreateDTO>().ReverseMap();
            CreateMap<Avaliacao, AvaliacaoUpdateDTO>().ReverseMap();

            CreateMap<CarrinhoCompra, CarrinhoCompraDTO>().ReverseMap();
            CreateMap<CarrinhoCompra, CarrinhoCompraCreateDTO>().ReverseMap();
            CreateMap<CarrinhoCompra, CarrinhoComprUpdateDTO>().ReverseMap();

            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaCreateDTO>().ReverseMap();

            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoCreateDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoUpdateDTO>().ReverseMap();

            CreateMap<Mensagem, MensagemDTO>().ReverseMap();
            CreateMap<Mensagem, MensagemCreateDTO>().ReverseMap();
            CreateMap<Mensagem, MensagemUpdateDTO>().ReverseMap();

            CreateMap<PlanoAssinatura, PlanoAssinaturaDTO>().ReverseMap();
            CreateMap<PlanoAssinatura, PlanoAssinaturaCreateDTO>().ReverseMap();
            CreateMap<PlanoAssinatura, PlanoAssinaturaUpdateDTO>().ReverseMap();

            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoCreateDTO>().ReverseMap();

            CreateMap<ProdutoFavorito, ProdutoFavoritoDTO>().ReverseMap();
            CreateMap<ProdutoFavorito, ProdutoFavoritoCreateDTO>().ReverseMap();

            CreateMap<ProdutosPedido, ProdutosPedidoDTO>().ReverseMap();
            CreateMap<ProdutosPedido, ProdutosPedidoCreateDTO>().ReverseMap();
            
            CreateMap<UnidadeMedida, UnidadeMedidaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

        }
    }
}
