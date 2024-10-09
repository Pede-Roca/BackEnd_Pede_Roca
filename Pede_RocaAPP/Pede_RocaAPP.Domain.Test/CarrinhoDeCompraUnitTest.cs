using FluentAssertions;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Domain.Test
{
    public class CarrinhoDeCompraUnitTest
    {
        [Fact(DisplayName = "Com todos os valores válidos")]
        public void CreateCarrinhoCompra_ParametrosValidos()
        {
            var data = DateTime.Now;
            var idUsuario = Guid.NewGuid();
            var idProdutosPedido = Guid.NewGuid();

            Action action = () => new CarrinhoCompra(data, "Em processamento", idUsuario, idProdutosPedido);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Data inválida")]

        public void CreateCarrinhoCompra_ParametrosInvalidos_data()
        {
            var data = DateTime.MinValue;
            var idUsuario = Guid.NewGuid();
            var idProdutosPedido = Guid.NewGuid();

            Action action = () => new CarrinhoCompra(data, "Em processamento", idUsuario, idProdutosPedido);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Data inválida.");
        }

        [Fact(DisplayName = "ID de usuário inválido")]

        public void CreateCarrinhoCompra_ParametrosInvalidos_idUsuario()
        {
            var data = DateTime.Now;
            var idProdutosPedido = Guid.NewGuid();

            Action action = () => new CarrinhoCompra(data, "Em processamento", Guid.Empty, idProdutosPedido);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID de usuário inválido.");
        }

        [Fact(DisplayName = "ID de produtos pedidos inválido.")]

        public void CreateCarrinhoCompra_ParametrosInvalidos_idProdutosPedido()
        {
            var data = DateTime.Now;
            var idUsuario = Guid.NewGuid();

            Action action = () => new CarrinhoCompra(data, "Em processamento", idUsuario, Guid.Empty);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID de produtos pedidos inválido.");
        }


        }
}