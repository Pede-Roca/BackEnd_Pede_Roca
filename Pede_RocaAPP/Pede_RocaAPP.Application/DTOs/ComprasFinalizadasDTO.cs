using Pede_RocaAPP.Domain.Entities;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Pede_RocaAPP.Application.DTOs
{
    public class ComprasFinalizadasDTO
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Data")]        
        public DateTime Data { get; set; }
        
        [DisplayName("Status")]
        public bool Status { get; set; }

        [DisplayName("Data da Entrega")]
        public DateTime? DataEntrega { get; set; }

        [DisplayName("Id do Carrinho de Compra")]
        public Guid IdCarrinhoCompra { get; set; }

        [DisplayName("Id do Produto do Pedido")]
        public Guid IdProdutosPedido { get; set; }
    }

    public class ComprasFinalizadasCreateDTO
    {
        [JsonIgnore]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        [JsonIgnore]
        [DisplayName("Data da Entrega")]
        public DateTime? DataEntrega { get; set; }

        [DisplayName("Id do Carrinho de Compra")]
        public Guid IdCarrinhoCompra { get; set; }

        [DisplayName("Id do Produto do Pedido")]
        public Guid IdProdutosPedido { get; set; }
    }
}
