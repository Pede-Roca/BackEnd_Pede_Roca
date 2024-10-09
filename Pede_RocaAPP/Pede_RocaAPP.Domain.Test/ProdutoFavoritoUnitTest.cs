using FluentAssertions;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Action action = () => new ProdutoFavorito(idUsuario,idProduto);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Dados do Produto válidos")]
        public void CreateProdutoFavorito_ParametrosInvalidos_idProduto()
        {
            var idUsuario = Guid.NewGuid();
            Action action = () => new ProdutoFavorito(Guid.Empty, idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID do produto inválido.");
        }
        public void CreateProdutoFavorito_ParametroInválido_idUsuario()
        {
            var idUsuario = Guid.NewGuid();
            Action action = () => new ProdutoFavorito(idUsuario, Guid.Empty);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("ID do produto inválido.");
        }
    }
}
