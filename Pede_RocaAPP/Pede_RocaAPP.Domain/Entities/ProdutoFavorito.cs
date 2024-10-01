using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class ProdutoFavorito
    {
        [Key]
        public Guid Id { get; set; }
        public Produto IdProduto { get; set; }
        public Usuario IdUsuario { get; set; }

        public ProdutoFavorito()
        {
        }

        public ProdutoFavorito(Guid id, Produto idProduto, Usuario idUsuario)
        {
            Id = Guid.NewGuid();
            IdProduto = idProduto;
            IdUsuario = idUsuario;
        }
    }
}
