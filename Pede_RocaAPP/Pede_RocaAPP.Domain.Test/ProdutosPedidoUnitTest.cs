using FluentAssertions;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;
using System;

namespace Pede_RocaAPP.Domain.Test
{
    public class ProdutosPedidoUnitTest
    {
        [Fact(DisplayName = "Pedido com quantidade de produtos válida")]
        public void CreateProdutosPedido_ParametrosValidos()
        {
            // Incluindo o valorTotal no construtor
            Action action = () => new ProdutosPedido(10, Guid.NewGuid(), 100.00m);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Id do produto inválido - Guid.Empty")]
        public void CreateProdutosPedido_ParametrosInvalidos_IdProdutoInvalido()
        {
            // Incluindo o valorTotal no construtor
            Action action = () => new ProdutosPedido(10, Guid.Empty, 100.00m);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id do produto inválido, ele é obrigatório.");
        }

        [Fact(DisplayName = "Quantidade de produtos inválida - Menor que 1")]
        public void CreateProdutosPedido_ParametrosInvalidos_QuantidadeMenor()
        {
            // Incluindo o valorTotal no construtor
            Action action = () => new ProdutosPedido(0, Guid.NewGuid(), 100.00m);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Quantidade de produto inválida, deve ser maior que 0.");
        }
    }
}
