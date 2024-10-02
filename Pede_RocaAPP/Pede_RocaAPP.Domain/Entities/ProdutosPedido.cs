using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pede_RocaAPP.Domain.Validation;

namespace Pede_RocaAPP.Domain.Entities
{
    public class ProdutosPedido
    {
        [Key]
        public Guid Id { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de produto deve ser maior que 0.")]
        public int QuantidadeProduto { get; set; }

        [Required(ErrorMessage = "O Id do produto é obrigatório.")]
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; } // Propriedade de navegação para Produto

        [Required(ErrorMessage = "O Id do carrinho de compra é obrigatório.")]
        public Guid IdCarrinhoCompra { get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; } // Propriedade de navegação

        public ProdutosPedido()
        {
        }

        public ProdutosPedido(int quantidadeProduto, Guid idProduto)
        {
            ValidateDomain(quantidadeProduto, idProduto);
            Id = Guid.NewGuid();
            QuantidadeProduto = quantidadeProduto;
            IdProduto = idProduto;
        }

        private void ValidateDomain(int quantidadeProduto, Guid idProduto)
        {
            DomainExceptionValidation.When(quantidadeProduto <= 0, "Quantidade de produto inválida, deve ser maior que 0.");
            DomainExceptionValidation.When(idProduto == Guid.Empty, "Id do produto inválido, ele é obrigatório.");
        }
    }
}
