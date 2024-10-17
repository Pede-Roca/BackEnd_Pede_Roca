using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Pede_RocaAPP.Application.DTOs
{
    public class CarrinhoComprasProdutosPedidoDTO
    {
        [JsonIgnore]
        [DisplayName("Id")]
        public Guid Id { get; set; } // Identificador da tabela de junção
        
        [DisplayName("Id do Carrinho de Compra")]
        public Guid IdCarrinhoCompra { get; set; } // Chave estrangeira para CarrinhoCompra

        [DisplayName("Id do Produto do Pedido")]
        public Guid IdProdutosPedido { get; set; } // Chave estrangeira para ProdutosPedido

    }
}
