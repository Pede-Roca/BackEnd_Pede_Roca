using Pede_RocaAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pede_RocaAPP.Application.DTOs
{
    public class ProdutoFavoritoDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O identificador do Produto é obrigatório.")]
        [DisplayName("IdProduto")]
        public Guid IdProduto { get; set; }
        
        [Required(ErrorMessage = "O identificador do Usuario é obrigatório.")]
        [DisplayName("IdUsuario")]
        public Guid IdUsuario { get; set; }
    }

    public class ProdutoFavoritoCreateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O identificador do Produto é obrigatório.")]
        [DisplayName("IdProduto")]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "O identificador do Usuario é obrigatório.")]
        [DisplayName("IdUsuario")]
        public Guid IdUsuario { get; set; }
    }
}
