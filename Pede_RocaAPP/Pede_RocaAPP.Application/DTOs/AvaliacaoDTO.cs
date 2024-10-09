using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.DTOs
{
    public class AvaliacaoCreateDTO
    {
        [JsonIgnore]
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
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "O Id do Carrinho de Compra é obrigatório.")]
        [DisplayName("Carrinho de Compra")]
        public Guid IdCarrinhoCompra { get; set; }
    }

    public class AvaliacaoUpdateDTO
    {
        [JsonIgnore]
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
        [JsonIgnore]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "O Id do Carrinho de Compra é obrigatório.")]
        [DisplayName("Carrinho de Compra")]
        [JsonIgnore]
        public Guid IdCarrinhoCompra { get; set; }
    }

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
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "O Id do Carrinho de Compra é obrigatório.")]
        [DisplayName("Carrinho de Compra")]
        public Guid IdCarrinhoCompra { get; set; }
    }
}