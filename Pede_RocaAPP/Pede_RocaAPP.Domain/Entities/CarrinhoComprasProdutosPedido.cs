namespace Pede_RocaAPP.Domain.Entities
{    
    public class CarrinhoComprasProdutosPedido
    {
        public Guid Id { get; set; } // Identificador da tabela de junção
        public Guid IdCarrinhoCompra { get; set; } // Chave estrangeira para CarrinhoCompra
        public Guid IdProdutosPedido { get; set; } // Chave estrangeira para ProdutosPedido

        // Propriedades de navegação
        public CarrinhoCompra CarrinhoCompra { get; set; } // Navegação para CarrinhoCompra
        public ProdutosPedido ProdutosPedido { get; set; } // Navegação para ProdutosPedido

        public CarrinhoComprasProdutosPedido() { }

        public CarrinhoComprasProdutosPedido(Guid idCarrinhoCompras, Guid idProdutosPedido)
        {
            Id = Guid.NewGuid();
            IdCarrinhoCompra = idCarrinhoCompras;
            IdProdutosPedido = idProdutosPedido;
        }
    }
}
