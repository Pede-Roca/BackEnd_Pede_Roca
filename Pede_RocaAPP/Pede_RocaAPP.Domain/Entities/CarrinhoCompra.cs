using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;
namespace Pede_RocaAPP.Domain.Entities
{
    public class CarrinhoCompra
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O status deve ter entre 3 e 50 caracteres.")]
        public string Status { get; set; }

        // Chave estrangeira para Usuario
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; } // Propriedade de navegação

        // Propriedade de navegação para ProdutosPedido
        [Required(ErrorMessage = "O carrinho de compras deve conter ao menos um produto.")]
        public ProdutosPedido ProdutosPedido { get; set; }
        public Guid IdProdutosPedido { get; set; }

        
        public CarrinhoCompra()
        {
        }

        public CarrinhoCompra(DateTime data, string status, Guid idUsuario, Guid idProdutosPedido)
        {
            Id = Guid.NewGuid();
            ValidateDomain(data, status, idUsuario, idProdutosPedido);
            Data = data;
            Status = status;
            IdUsuario = idUsuario;
            IdProdutosPedido = idProdutosPedido;
        }

        public CarrinhoCompra(DateTime data, string v)
        {
            Data = data;
        }

        private void ValidateDomain(DateTime data, string status, Guid idUsuario, Guid idProdutosPedido)
        {

            DomainExceptionValidation.When(data == default(DateTime), "Data inválida.");
            DomainExceptionValidation.When(status.Length < 3 || status.Length > 50, "O status deve ter entre 3 e 50 caracteres.");
            DomainExceptionValidation.When(idUsuario == Guid.Empty, "ID de usuário inválido.");
            DomainExceptionValidation.When(idProdutosPedido == Guid.Empty, "ID de produtos pedidos inválido.");
        }
    }
}

