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
    public class AvaliacaoUnitTest
    {
        [Fact(DisplayName = "Com todos os valores válidos")]
        public void CreateAvaliacao_ParametrosValidos()
        {
            var validUserId = Guid.NewGuid();
            var validCarrinhoCompraId = Guid.NewGuid();

            Action action = () => new Avaliacao(5, "Produto muito bom", validUserId, validCarrinhoCompraId);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Dados de nota inválidos - Menor que 1")]
        public void CreateAvaliacao_PaarametrosInvalidos_NotaMenor()
        {
            Action action = () => new Avaliacao(0, "Não gostei", new Guid(), new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nota inválida, deve estar entre 1 e 5.");
        }

        [Fact(DisplayName = "Dados de nota inválidos - Maior que 5")]
        public void CreateAvaliacao_PaarametrosInvalidos_NotaMaior()
        {
            Action action = () => new Avaliacao(6, "Não gostei", new Guid(), new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nota inválida, deve estar entre 1 e 5.");
        }

        [Fact(DisplayName = "Dados de descrição inválidos - Descrição vazia")]
        public void CreateAvaliacao_ParametrosInvalidos_DescricaoVazia()
        {
            Action action = () => new Avaliacao(3, "", new Guid(), new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A descrição é obrigatória.");
        }

        [Fact(DisplayName = "Dados de descrição inválidos - Descrição menor que 10 caracteres")]
        public void CreateAvaliacao_ParametrosInvalidos_DescricaoCurta()
        {
            Action action = () => new Avaliacao(4, "Muito bom", new Guid(), new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A descrição deve ter entre 10 e 500 caracteres.");
        }

        [Fact(DisplayName = "Dados de descrição inválidos - Descrição maior que 500 caracteres")]
        public void CreateAvaliacao_ParametrosInvalidos_DescricaoLonga()
        {
            var longDescription = new string('a', 501);
            Action action = () => new Avaliacao(4, longDescription, new Guid(), new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A descrição deve ter entre 10 e 500 caracteres.");
        }

        [Fact(DisplayName = "Dados de ID de usuário inválido - Guid.Empty")]
        public void CreateAvaliacao_ParametrosInvalidos_IdUsuarioVazio()
        {
            var validCarrinhoCompraId = Guid.NewGuid();
            Action action = () => new Avaliacao(4, "Produto excelente", Guid.Empty, validCarrinhoCompraId);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID de usuário inválido.");
        }

        [Fact(DisplayName = "Dados de ID de carrinho de compras inválido - Guid.Empty")]
        public void CreateAvaliacao_ParametrosInvalidos_IdCarrinhoCompraVazio()
        {
            var validUserId = Guid.NewGuid();
            Action action = () => new Avaliacao(4, "Produto excelente", validUserId, Guid.Empty);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID de carrinho de compras inválido.");
        }
    }
}
