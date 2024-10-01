using Pede_RocaAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Application.DTOs
{
    public class ProdutoFavoritoDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O identificador do Produto é obrigatório.")]
        [DisplayName("IdProduto")]
        public List<Produto> IdProduto { get; set; }
        
        [Required(ErrorMessage = "O identificador do Usuario é obrigatório.")]
        [DisplayName("IdUsuario")]
        public Usuario IdUsuario { get; set; }
    }
}
