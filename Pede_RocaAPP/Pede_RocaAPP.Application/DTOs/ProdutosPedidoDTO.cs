using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.DTOs
{
    public class ProdutosPedidoDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A quantidade do produto é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1.")]
        [DisplayName("Quantidade do Produto")]
        public int QuantidadeProduto { get; set; }

        [Required(ErrorMessage = "O valor total do produto é obrigatório.")]
        [DisplayName("Valor Total do Produto")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O ID do produto é obrigatório.")]
        [DisplayName("ID do Produto")]
        public Guid IdProduto { get; set; }
    }

    public class ProdutosPedidoCreateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A quantidade do produto é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1.")]
        [DisplayName("Quantidade do Produto")]
        public int QuantidadeProduto { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "O valor total do produto é obrigatório.")]
        [DisplayName("Valor Total do Produto")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O ID do produto é obrigatório.")]
        [DisplayName("ID do Produto")]
        public Guid IdProduto { get; set; }
    }
}
