using FluentAssertions;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;
using System;

namespace Pede_RocaAPP.Domain.Test
{
    public class UsuarioUnitTest
    {
        [Fact(DisplayName = "Criar usuario com dados válidos")]
        public void CreateUsuario_ParametrosValidos()
        {
            Action action = () => new Usuario("Maria Souza", "maria@gmail.com", "123456", "(11)99999-9999", "84459721031", new DateTime(2000, 07, 02, 22, 59, 59), "Admin", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Email com formato inválido")]
        public void CreateUsuario_ParametrosInvalidos_EmailInvalido()
        {
            Action action = () => new Usuario("Maria Souza", "mariagmail.com", "123456", "(11)99999-9999", "84459721031", new DateTime(2000, 07, 02, 22, 59, 59), "Admin", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("E-mail inválido.");
        }

        [Fact(DisplayName = "Senha inválida - Menor que 6")]
        public void CreateUsuario_ParametrosInvalidos_SenhaMenor()
        {
            Action action = () => new Usuario("Maria Souza", "maria@gmail.com", "12345", "(11)99999-9999", "84459721031", new DateTime(2000, 07, 02, 22, 59, 59), "Admin", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A senha deve ter no mínimo 6 caracteres.");
        }

        [Fact(DisplayName = "Nome inválido - Nulo ou vazio")]
        public void CreateUsuario_ParametrosInvalidos_NomeVazio()
        {
            Action action = () => new Usuario("", "maria@gmail.com", "123456", "(11)99999-9999", "84459721031", new DateTime(2000, 07, 02, 22, 59, 59), "Admin", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Nome inválido - Menor que 3")]
        public void CreateUsuario_ParametrosInvalidos_NomeMenor()
        {
            Action action = () => new Usuario("Ma", "maria@gmail.com", "123456", "(11)99999-9999", "84459721031", new DateTime(2000, 07, 02, 22, 59, 59), "Admin", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome deve ter entre 3 e 100 caracteres.");
        }

        [Fact(DisplayName = "Nome inválido - Maior que 100")]
        public void CreateUsuario_ParametrosInvalidos_NomeMaior()
        {
            var nomeUsuario = new string('a', 101);
            Action action = () => new Usuario(nomeUsuario, "maria@gmail.com", "123456", "(11)99999-9999", "84459721031", new DateTime(2000, 07, 02, 22, 59, 59), "Admin", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome deve ter entre 3 e 100 caracteres.");
        }

        [Fact(DisplayName = "Telefone inválido - Nulo ou vazio")]
        public void CreateUsuario_ParametrosInvalidos_TelefoneVazio()
        {
            Action action = () => new Usuario("Maria Souza", "maria@gmail.com", "123456", "", "84459721031", new DateTime(2000, 07, 02, 22, 59, 59), "Admin", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone é obrigatório.");
        }


        [Fact(DisplayName = "CPF inválido")]
        public void CreateUsuario_ParametrosInvalidos_CPFInvalido()
        {
            Action action = () => new Usuario("Maria Souza", "maria@gmail.com", "123456", "(11)99999-9999", "84459721", new DateTime(2000, 07, 02, 22, 59, 59), "Admin", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("CPF inválido.");
        }

        [Fact(DisplayName = "Nivel de acesso inválido - Nulo ou vazio")]
        public void CreateUsuario_ParametrosInvalidos_NivelAcessoVazio()
        {
            Action action = () => new Usuario("Maria Souza", "maria@gmail.com", "123456", "(11)99999-9999", "84459721031", new DateTime(2000, 07, 02, 22, 59, 59), "", "123456789-ABCEEFGH", true, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nível de acesso é obrigatório.");
        }
    }
}

