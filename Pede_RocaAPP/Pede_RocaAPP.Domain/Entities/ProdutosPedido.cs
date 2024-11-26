using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pede_RocaAPP.Domain.Validation;

namespace Pede_RocaAPP.Domain.Entities
{
    public class ProdutosPedido
    {
        public Guid Id { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid IdProduto { get; set; }


        public Produto Produto { get; set; }
        public ICollection<CarrinhoComprasProdutosPedido> CarrinhoComprasProdutosPedido { get; set; } // Relacionamento com CarrinhoCompra

        public ProdutosPedido() { }

        public ProdutosPedido(int quantidadeProduto, Guid idProduto, decimal valorTotal)
        {
            Id = Guid.NewGuid();
            ValidateDomain(quantidadeProduto, idProduto);
            ValorTotal = valorTotal;
            QuantidadeProduto = quantidadeProduto;
            IdProduto = idProduto;
        }

        private void ValidateDomain(int quantidadeProduto, Guid idProduto)
        {
            DomainExceptionValidation.When(quantidadeProduto <= 0, "Quantidade de produto inválida, deve ser maior que 0.");
            DomainExceptionValidation.When(idProduto == Guid.Empty, "Id do produto inválido, ele é obrigatório.");
        }
    }

    public class ProdutoPedidoAtualizarEstoqueRequest
    {
        public Guid IdCarrinhoCompra { get; set; }
        public int Quantidade { get; set; }
        public bool Adicionar { get; set; }
    }
}
