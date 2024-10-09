using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pede_RocaAPP.Application.DTOs
{
    public class CarrinhoCompraDTO
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Status do pedido é obrigatório.")]
        [DisplayName("Status")]
        [MaxLength(20, ErrorMessage = "O Status do pedido deve ter no máximo 20 caracteres.")]
        public string Status { get; set; }

        public Guid IdUsuario { get; set; }

        public Guid IdProdutosPedido { get; set; }
    }

    public class CarrinhoCompraCreateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Status do pedido é obrigatório.")]
        [DisplayName("Status")]
        [MaxLength(20, ErrorMessage = "O Status do pedido deve ter no máximo 20 caracteres.")]
        public string Status { get; set; }

        public Guid IdUsuario { get; set; }

        public Guid IdProdutosPedido { get; set; }
    }

    public class CarrinhoComprUpdateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data")]
        [JsonIgnore]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Status do pedido é obrigatório.")]
        [DisplayName("Status")]
        [MaxLength(20, ErrorMessage = "O Status do pedido deve ter no máximo 20 caracteres.")]
        public string Status { get; set; }

        [JsonIgnore]
        public Guid IdUsuario { get; set; }

        [JsonIgnore]
        public Guid IdProdutosPedido { get; set; }
    }
}