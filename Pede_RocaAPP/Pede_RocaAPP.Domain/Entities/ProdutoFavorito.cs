using Pede_RocaAPP.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class ProdutoFavorito
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório.")]
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public ProdutoFavorito()
        {
        }

        public ProdutoFavorito(Guid idProduto, Guid idUsuario)
        {
            Id = Guid.NewGuid();
            ValidateDomain(idProduto, idUsuario);
            IdProduto = idProduto;
            IdUsuario = idUsuario;
        }

        private void ValidateDomain(Guid idProduto, Guid idUsuario)
        {
            DomainExceptionValidation.When(idUsuario == Guid.Empty, "ID de usuário inválido.");
            DomainExceptionValidation.When(idProduto == Guid.Empty, "ID do produto inválido.");
        }
    }
}
