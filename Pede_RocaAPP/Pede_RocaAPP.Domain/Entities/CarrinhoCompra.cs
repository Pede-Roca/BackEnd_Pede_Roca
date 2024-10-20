using Pede_RocaAPP.Domain.Validation;
namespace Pede_RocaAPP.Domain.Entities
{
    public class CarrinhoCompra
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public bool Status { get; set; } = true;
        public Guid IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<CarrinhoComprasProdutosPedido> CarrinhoComprasProdutosPedido { get; set; } // Relacionamento com ProdutosPedido

        public CarrinhoCompra() { }

        public CarrinhoCompra(DateTime data, Guid idUsuario)
        {
            Id = Guid.NewGuid();
            ValidateDomain(data, idUsuario);
            Data = data;
            Status = true;
            IdUsuario = idUsuario;
        }

        public CarrinhoCompra(DateTime data, string v)
        {
            Data = data;
        }

        private void ValidateDomain(DateTime data, Guid idUsuario)
        {

            DomainExceptionValidation.When(data == default(DateTime), "Data inválida.");
            DomainExceptionValidation.When(idUsuario == Guid.Empty, "ID de usuário inválido.");
        }
    }

    public class ItensCarrinhoCompra
    {
        public Guid IdProdutoPedido { get; set; }

        public int Quantidade { get; set; }

        public Guid IdProduto { get; set; }

        public string NomeProduto { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public ItensCarrinhoCompra(Guid idProdutosPedido, int quantidade, Guid idProduto, string nomeProduto, decimal preco, int estoque)
        {
            IdProdutoPedido = idProdutosPedido;
            Quantidade = quantidade;
            IdProduto = idProduto;
            NomeProduto = nomeProduto;
            Preco = preco;
            Estoque = estoque;
        }
    }

    public class ItemCarrinho
    {
        public Guid IdCarrinhoCompra { get; set; }
        public Guid IdProduto { get; set; }
        public int QuantidadeComprada { get; set; }
        public int EstoqueProduto { get; set; }
    }

    public class FinalizarCompraResponse
    {
        public Guid IdCarrinhoCompra { get; set; }
        public bool Sucesso { get; set; }
        public List<ItemCarrinho> ProdutosSemEstoque { get; set; }
        public string Message { get; set; }

        public FinalizarCompraResponse()
        {
            ProdutosSemEstoque = new List<ItemCarrinho>();
        }
    }

    public class CarrinhoComprasRemoverProdutosPedidoRequest
    {
        public Guid IdCarrinhoCompra { get; set; }
        public Guid IdProdutoPedido { get; set; }
    }
}