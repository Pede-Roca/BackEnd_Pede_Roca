using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class ProdutosPedido
    {
        [Key]
        public Guid Id { get; set; }
        public int QuantidadeProduto { get; set; }
        public Produto IdProduto { get; set; }

        public ProdutosPedido()
        {
        }

        public ProdutosPedido(int quantidadeProduto, Produto idProduto)
        {
            Id = Guid.NewGuid();
            QuantidadeProduto = quantidadeProduto;
            IdProduto = idProduto;
        }
    }
}