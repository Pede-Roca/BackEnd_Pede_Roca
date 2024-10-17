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
    public class EnderecoUnitTest
    {
        [Fact(DisplayName = "Criar usuario com dados válidos")]
        public void CreateEndereco_ParametrosValidos()
        {
            Action action = () => new Endereco("15991-510", "Matão", "SP", "Rua Para", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CEP inválido - Formato errado")]
        public void CreateEndereco_ParametrosInvalidos_CEP()
        {
            Action action = () => new Endereco("15991510", "Matão", "SP", "Rua Para", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("CEP inválido, deve estar no formato 00000-000.");
        }

        [Fact(DisplayName = "CEP inválido - CEP vazio")]
        public void CreateEndereco_ParametrosInvalidos_CEPVazio()
        {
            Action action = () => new Endereco("", "Matão", "SP", "Rua Para", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("CEP inválido, deve estar no formato 00000-000.");
        }

        [Fact(DisplayName = "Cidade inválida - Menor que 2")]
        public void CreateEndereco_ParametrosInvalidos_CidadeMenor()
        {
            Action action = () => new Endereco("15991-510", "M", "SP", "Rua Para", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A cidade deve ter entre 2 e 100 caracteres.");
        }

        [Fact(DisplayName = "Cidade inválida - Maior que 100")]
        public void CreateEndereco_ParametrosInvalidos_CidadeMaior()
        {
            var cidade = new string('a', 101);
            Action action = () => new Endereco("15991-510", cidade, "SP", "Rua Para", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A cidade deve ter entre 2 e 100 caracteres.");
        }

        [Fact(DisplayName = "Cidade inválida - Cidade vazia")]
        public void CreateEndereco_ParametrosInvalidos_CidadeVazia()
        {
            Action action = () => new Endereco("15991-510", "", "SP", "Rua Para", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A cidade deve ter entre 2 e 100 caracteres.");
        }

        [Fact(DisplayName = "Estado inválido - Diferente de 2")]
        public void CreateEndereco_ParametrosInvalidos_EstadoDiferente()
        {
            Action action = () => new Endereco("15991-510", "Matão", "São", "Rua Para", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O estado deve ter 2 caracteres.");
        }

        [Fact(DisplayName = "Estado inválido - Estado vazio")]
        public void CreateEndereco_ParametrosInvalidos_EstadoVazio()
        {
            Action action = () => new Endereco("15991-510", "Matão", "", "Rua Para", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O estado deve ter 2 caracteres.");
        }

        [Fact(DisplayName = "Logradouro inválido - Menor que 3")]
        public void CreateEndereco_ParametrosInvalidos_LogradouroMenor()
        {
            Action action = () => new Endereco("15991-510", "Matão", "SP", "Av", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O logradouro deve ter entre 3 e 150 caracteres.");
        }

        [Fact(DisplayName = "Logradouro inválido - Maior que 150")]
        public void CreateEndereco_ParametrosInvalidos_LogradouroMaior()
        {
            var logradouro = new string('a', 151);
            Action action = () => new Endereco("15991-510", "Matão", "SP", logradouro, "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O logradouro deve ter entre 3 e 150 caracteres.");
        }

        [Fact(DisplayName = "Logradouro inválido - Logradouro vazio")]
        public void CreateEndereco_ParametrosInvalidos_LogradouroVazio()
        {
            Action action = () => new Endereco("15991-510", "Matão", "SP", "", "Centro", 12, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O logradouro deve ter entre 3 e 150 caracteres.");
        }

        [Fact(DisplayName = "Número inválido - Número vazio")]
        public void CreateEndereco_ParametrosInvalidos_NúmeroVazio()
        {
            Action action = () => new Endereco("15991-510", "Matão", "SP", "Rua Para", "Centro", 0, "Sem complemento", new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O número deve ser maior que zero.");
        }

        [Fact(DisplayName = "Complemento inválido - Complemento maior que 150")]
        public void CreateEndereco_ParametrosInvalidos_ComplementoMaior()
        {
            var complemento = new string('a', 151);
            Action action = () => new Endereco("15991-510", "Matão", "SP", "Rua Para", "Centro", 12, complemento, new Guid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O complemento deve ter no máximo 150 caracteres.");
        }

        [Fact(DisplayName = "ID inválido - ID de usuário inválido")]
        public void CreateEndereco_ParametrosInvalidos_UsuarioVazio()
        {
            Action action = () => new Endereco("15991-510", "Matão", "SP", "Rua Para", "Centro", 12, "Sem complemento", Guid.Empty);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID de usuário inválido.");
        }
    }
}
