using FluentAssertions;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;

namespace Pede_RocaAPP.Domain.Test
{
    public class ProdutoFavoritoUnitTest
    {
        [Fact(DisplayName = "Com todos os valores válidos")]
        public void CreateProdutoFavorito_ParametrosValidos()
        {
            var idUsuario = Guid.NewGuid();
            var idProduto = Guid.NewGuid();

            Action action = () => new ProdutoFavorito(idUsuario, idProduto);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Valor Inválido de usuário")]
        public void CreateProdutoFavorito_ParametrosInvalidos_idProduto()
        {
            var idUsuario = Guid.NewGuid();
            Action action = () => new ProdutoFavorito(Guid.Empty, idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID do produto inválido.");
        }
        [Fact(DisplayName = "Valore inválido de Produto")]
        public void CreateProdutoFavorito_ParametroInválido_idUsuario()
        {
            var idProduto = Guid.NewGuid();
            Action action = () => new ProdutoFavorito(idProduto, Guid.Empty);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID de usuário inválido.");
        }
    }
}
