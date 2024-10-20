using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pede_RocaAPP.Application.DTOs
{
    public class CarrinhoCompraDTO
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        [DisplayName("Id do Usuario")]
        public Guid IdUsuario { get; set; }
    }

    public class CarrinhoCompraCreateDTO
    {
        [JsonIgnore]

        [DisplayName("Id")]
        public Guid Id { get; set; }

        [JsonIgnore]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [JsonIgnore]
        [DisplayName("Status")]
        public bool Status { get; set; }

        [DisplayName("Id do Usuario")]
        public Guid IdUsuario { get; set; }
    }

    public class CarrinhoCompraUpdateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [DisplayName("Data")]
        [JsonIgnore]
        public DateTime Data { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        [JsonIgnore]
        public Guid IdUsuario { get; set; }
    }

    public class ItensCarrinhoCompraDTO
    {
        [DisplayName("Id de Produtos Pedidos")]
        public string IdProdutoPedido { get; set; }

        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        [DisplayName("Id do Produto")]
        public Guid IdProduto { get; set; }

        [DisplayName("Nome do Produto")]
        public string NomeProduto { get; set; }

        [DisplayName("Preço do Produto")]
        public decimal Preco { get; set; }

        [DisplayName("Quantidade em Estoque")]
        public int Estoque { get; set; }
    }
}