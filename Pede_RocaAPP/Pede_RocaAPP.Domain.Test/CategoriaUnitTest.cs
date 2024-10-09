using FluentAssertions;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;

namespace Pede_RocaAPP.Domain.Test
{
    public class CategoriaUnitTest
    {
        [Fact(DisplayName = "Criar categoria com nome válido")]
        public void CreateCategoria_ParametrosValidos()
        {
            Action action = () => new Categoria("Frutas");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Nome de categoria inválido - Menor que 3")]
        public void CreateCategoria_ParametrosInvalidos_NomeMenor()
        {
            Action action = () => new Categoria("Le");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome deve ter entre 3 e 100 caracteres.");
        }

        [Fact(DisplayName = "Nome de categoria inválido - Maior que 100")]
        public void CreateCategoria_ParametrosInvalidos_NomeMaior()
        {
            var nomeCategoria = new string('a', 101);
            Action action = () => new Categoria(nomeCategoria);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome deve ter entre 3 e 100 caracteres.");
        }

        [Fact(DisplayName = "Nome de categoria inválido - Nulo ou vazio")]
        public void CreateCategoria_ParametrosInvalidos_NomeVazio()
        {
            Action action = () => new Categoria("");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome é obrigatório.");
        }
    }
}
