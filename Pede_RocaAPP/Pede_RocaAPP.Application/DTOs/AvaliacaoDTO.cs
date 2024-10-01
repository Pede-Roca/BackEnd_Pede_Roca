using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.DTOs
{
    public class AvaliacaoDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A Nota é obrigatória.")]
        [Range(1, 5, ErrorMessage = "A Nota deve ser entre 1 e 5.")]
        [DisplayName("Nota")]
        public int Nota { get; set; }

        [MaxLength(500, ErrorMessage = "A Descrição pode ter no máximo 500 caracteres.")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Id do Usuário é obrigatório.")]
        [DisplayName("Usuário")]
        public Usuario IdUsuario { get; set; }

        [Required(ErrorMessage = "O Id do Carrinho de Compra é obrigatório.")]
        [DisplayName("Carrinho de Compra")]
        public CarrinhoCompra IdCarrinhoCompra { get; set; }
    }
}