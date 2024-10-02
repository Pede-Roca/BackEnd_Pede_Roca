using System;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class ProdutoFavorito
    {
        [Key]
        public Guid Id { get; set; }

        // Relacionamento com Produto
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; }

        // Relacionamento com Usuario
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public ProdutoFavorito()
        {
        }

        public ProdutoFavorito(Guid idProduto, Guid idUsuario)
        {
            Id = Guid.NewGuid();
            IdProduto = idProduto;
            IdUsuario = idUsuario;
        }
    }
}
