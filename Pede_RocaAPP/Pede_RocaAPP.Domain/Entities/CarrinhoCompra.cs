using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class CarrinhoCompra
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public Usuario IdUsuario { get; set; }
        public List<ProdutosPedido> IdProdutosPedido { get; set; }

        public CarrinhoCompra()
        {
        }

        public CarrinhoCompra(DateTime data, string status, Usuario idUsuario, List<ProdutosPedido> idProdutosPedido)
        {
            Id = Guid.NewGuid();
            Data = data;
            Status = status;
            IdUsuario = idUsuario;
            IdProdutosPedido = idProdutosPedido;
        }
    }
}