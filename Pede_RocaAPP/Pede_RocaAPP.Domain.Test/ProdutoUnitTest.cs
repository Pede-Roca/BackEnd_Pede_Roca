using FluentAssertions;
using FluentAssertions.Equivalency;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Test
{
    public class ProdutoUnitTest
    {
        [Fact(DisplayName = "Cria produto com valores validos")]
        public void CreateProduto_ParametrosValidos()
        {
            Action action = () => new Produto("Banana", "A banana é rica em potássio", 10, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Nome inválido - Nulo ou vazio")]
        public void CreateProduto_ParametrosInvalidos_NomeVazio()
        {
            Action action = () => new Produto("", "A banana é rica em potássio", 10, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome é obrigatório.");
        }

        [Fact(DisplayName = "Nome inválido - Menor que 3")]
        public void CreateProduto_ParametrosInvalidos_NomeMenor()
        {
            Action action = () => new Produto("Ba", "A banana é rica em potássio", 10, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome deve ter entre 3 e 100 caracteres.");
        }

        [Fact(DisplayName = "Nome inválido - Maior que 100")]
        public void CreateProduto_ParametrosInvalidos_NomeMaior()
        {
            var nomeProduto = new string('a', 101);
            Action action = () => new Produto(nomeProduto, "A banana é rica em potássio", 10, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome deve ter entre 3 e 100 caracteres.");
        }

        [Fact(DisplayName = "Descrição inválida - Nulo ou vazio")]
        public void CreateProduto_ParametrosInvalidos_DescricaoVazio()
        {
            Action action = () => new Produto("Banana", "", 10, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A descrição é obrigatória.");
        }

        [Fact(DisplayName = "Descrição inválida - Menor que 5")]
        public void CreateProduto_ParametrosInvalidos_DescricaoMenor()
        {
            Action action = () => new Produto("Banana", "Doce", 10, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A descrição deve ter entre 5 e 200 caracteres.");
        }

        [Fact(DisplayName = "Descrição inválida - Maior que 200")]
        public void CreateProduto_ParametrosInvalidos_DescricaoMaior()
        {
            var descricaoProduto = new string('a', 201);
            Action action = () => new Produto("Banana", descricaoProduto, 10, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A descrição deve ter entre 5 e 200 caracteres.");
        }

        [Fact(DisplayName = "IdCategoria inválido - Nulo ou vazio")]
        public void CreateProduto_ParametrosInvalidos_IdCategoriaNulo()
        {
            Action action = () => new Produto("Banana", "A banana é rica em potássio", 10, 100, 1, "123456789-ABCDEFGH", Guid.Empty, Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O idCategoria é obrigatório.");
        }

        [Fact(DisplayName = "IdUnidade inválido - Nulo ou vazio")]
        public void CreateProduto_ParametrosInvalidos_IdUnidadeNulo()
        {
            Action action = () => new Produto("Banana", "A banana é rica em potássio", 10, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.Empty);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O idUnidade é obrigatório.");
        }

        [Fact(DisplayName = "Preço inválido - Nulo ou vazio")]
        public void CreateProduto_ParametrosInvalidos_PrecoNulo()
        {
            Action action = () => new Produto("Banana", "A banana é rica em potássio", 10.123m, 100, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Preço inválido. Deve ter no máximo duas casas decimais.");
        }

        [Fact(DisplayName = "Estoque inválido - Maior que 9999")]
        public void CreateProduto_ParametrosInvalidos_EstoqueMaior()
        {
            Action action = () => new Produto("Banana", "A banana é rica em potássio", 10, 10000, 1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Estoque inválido.");
        }

        [Fact(DisplayName = "Fator Promocional inválido - Menor que 0")]
        public void CreateProduto_ParametrosInvalidos_FatorPromocionalMenor()
        {
            Action action = () => new Produto("Banana", "A banana é rica em potássio", 10, 100, -1, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Fator promocional inválido.");
        }

        [Fact(DisplayName = "Fator Promocional inválido - Maior que 1")]
        public void CreateProduto_ParametrosInvalidos_FatorPromocionalMaior()
        {
            Action action = () => new Produto("Banana", "A banana é rica em potássio", 10, 100, 1.1m, "123456789-ABCDEFGH", Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Fator promocional inválido.");
        }

        [Fact(DisplayName = "UID Foto inválido - Maior que 250")]
        public void CreateProduto_ParametrosInvalidos_UIDFotoMaior()
        {
            var uidFoto = new string('A', 251);
            Action action = () => new Produto("Banana", "A banana é rica em potássio", 10, 100, 1, uidFoto, Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<DomainExceptionValidation>().WithMessage("UID da foto inválido.");
        }

    }
}
