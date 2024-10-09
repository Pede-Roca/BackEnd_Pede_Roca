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
    public class CategoriaUnitTest
    {
        [Fact(DisplayName = "Criar categoria com nome válido")]
        public void CreateCategoria_ParametrosValidos()
        {
            var idCategoria = Guid.NewGuid();
            Action action = () => new Categoria(idCategoria, "Frutas");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Nome de categoria inválido - Menor que 3")]
        public void CreateCategoria_ParametrosInvalidos_NomeMenor()
        {
            var idCategoria = Guid.NewGuid();
            Action action = () => new Categoria(idCategoria, "Le");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome deve ter entre 3 e 100 caracteres.");
        }

        [Fact(DisplayName = "Nome de categoria inválido - Maior que 100")]
        public void CreateCategoria_ParametrosInvalidos_NomeMaior()
        {
            var idCategoria = Guid.NewGuid();
            var nomeCategoria = new string('a', 101);
            Action action = () => new Categoria(idCategoria, nomeCategoria);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome deve ter entre 3 e 100 caracteres.");
        }

        [Fact(DisplayName = "Nome de categoria inválido - Nulo ou vazio")]
        public void CreateCategoria_ParametrosInvalidos_NomeVazio()
        {
            var idCategoria = Guid.NewGuid();
            Action action = () => new Categoria(idCategoria, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "ID da categoria inválido - Guid.Empty")]
        public void CreateCategoria_ParametrosInvalidos_IdCategoriaVazio()
        {
            var idCategoria = Guid.NewGuid();
            Action action = () => new Categoria(Guid.Empty, "Fruta");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID da categoria inválido.");
        }
    }
}

