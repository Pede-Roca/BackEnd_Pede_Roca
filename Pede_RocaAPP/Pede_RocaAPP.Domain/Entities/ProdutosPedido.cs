using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class ProdutosPedido
    {
        [Key]
        public Guid Id { get; set; }
        public int QuantidadeProduto { get; set; }

        // Supondo que você tenha uma propriedade para o produto
        public Guid IdProduto { get; set; }
        public Produto Produto { get; set; } // Propriedade de navegação para Produto

        // Chave estrangeira
        public Guid IdCarrinhoCompra { get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; } // Propriedade de navegação

        public ProdutosPedido()
        {
        }

        public ProdutosPedido(int quantidadeProduto, Guid idProduto)
        {
            Id = Guid.NewGuid();
            QuantidadeProduto = quantidadeProduto;
            IdProduto = idProduto; // O id do produto deve ser passado aqui
        }
    }
}
