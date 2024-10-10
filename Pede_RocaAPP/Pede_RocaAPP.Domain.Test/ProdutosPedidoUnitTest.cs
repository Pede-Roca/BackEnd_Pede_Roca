using FluentAssertions;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;

namespace Pede_RocaAPP.Domain.Test
{
    public class ProdutosPedidoUnitTest
    {
        [Fact(DisplayName = "Pedido com quantidade de produtos valida")]
        public void CreateProdutosPedido_ParametrosValidos()
        {
            Action action = () => new ProdutosPedido(10, Guid.NewGuid());
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Id do produto inválido - Guid.Empty")]
        public void CreateProdutosPedido_ParametrosInvalidos_IdProdutoInvalido()
        {
 
            Action action = () => new ProdutosPedido(10, Guid.Empty);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id do produto inválido, ele é obrigatório.");
        }

        [Fact(DisplayName = "Quantidade de produtos inválida - Menor que 1")]
        public void CreateProdutosPedido_ParametrosInvalidos_QuantidadeMenor()
        {
            Action action = () => new ProdutosPedido(0, Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Quantidade de produto inválida, deve ser maior que 0.");
        }
    }
}
