using FluentAssertions;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;

namespace Pede_RocaAPP.Domain.Test
{
    public class UnidadeMenidaUnitTest
    {
        [Fact(DisplayName = "Todos os valores válidos")]
        public void CreateUnidadeMedida_ParametrosValidos()
        {
            Action action = () => new UnidadeMedida("Metros", "m");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Dados de nomeUnidade vazio")]
        public void CreateUnidadeMedida_ParametroInvalido_nomeUnidade()
        {
            Action action = () => new UnidadeMedida("", "m");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome da unidade é obrigatório.");
        }

        [Fact(DisplayName = "Dados de nomeUnidade nulo")]
        public void CreateUnidadeMedida_ParametroInvalido_nomeUnidadeNulo()
        {
            Action action = () => new UnidadeMedida(null, "m");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome da unidade é obrigatório.");
        }

        [Fact(DisplayName = "nomeUnidade inválido - menos de 2 caracteres")]
        public void CreateUnidadeMedida_ParametroInvalido_nomeUnidadeMuitoCurto()
        {
            Action action = () => new UnidadeMedida("M", "m");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome da unidade deve ter entre 2 e 50 caracteres.");
        }

        [Fact(DisplayName = "nomeUnidade inválido - mais de 50 caracteres")]
        public void CreateUnidadeMedida_ParametroInvalido_nomeUnidadeMuitoLongo()
        {
            Action action = () => new UnidadeMedida(new string('A', 51), "m");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome da unidade deve ter entre 2 e 50 caracteres.");
        }

        [Fact(DisplayName = "siglaUnidade inválida - nula ou vazia")]
        public void CreateUnidadeMedida_ParametroInvalido_siglaUnidadeNulaOuVazia()
        {
            Action action = () => new UnidadeMedida("Metros", "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A sigla da unidade é obrigatória.");
        }

        [Fact(DisplayName = "siglaUnidade inválida - mais de 10 caracteres")]
        public void CreateUnidadeMedida_ParametroInvalido_siglaUnidadeMuitoLonga()
        {
            Action action = () => new UnidadeMedida("Metros", new string('m', 11));
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A sigla da unidade deve ter entre 1 e 10 caracteres.");
        }




    }
}
