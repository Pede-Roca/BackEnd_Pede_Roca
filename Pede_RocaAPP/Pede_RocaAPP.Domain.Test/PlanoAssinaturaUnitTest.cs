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
    public class PlanoAssinaturaUnitTest
    {
        [Fact(DisplayName = "Com todos os valores válidos")]
        public void CreatePlanodeAssinatura_ParametrosValidos()
        {
            var IdUsuario = Guid.NewGuid();

            Action action = () => new PlanoAssinatura(IdUsuario, 5, true);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Dados de preço inválidos - menor que 0")]

        public void CreatePlanodeAssinatura_ParametrosInvalidos_PrecoMenor0()
        {
            var IdUsuario = Guid.NewGuid();
            Action action = () => new PlanoAssinatura(IdUsuario, -1, false);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Preço inválido, deve ser maior ou igual a zero.");
        }
    }
}
