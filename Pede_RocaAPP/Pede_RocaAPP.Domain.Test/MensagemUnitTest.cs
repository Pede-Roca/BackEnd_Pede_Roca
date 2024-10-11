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
    public class MensagemUnitTest
    {
        [Fact(DisplayName = "Todos os dados válidos")]
        public void CreateMensagem_ParamentrosValidos()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.Now;

            Action action = () => new Mensagem(data, "teste@gmail.com", "Olá mundo", "imgTeste", "lida", idUsuario);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Horario inválido - formato errado")]
        public void CreateMensagem_ParametroInvalido_Horario()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.MinValue;

            Action action = () => new Mensagem(data, "teste@gmail.com", "Olá mundo", "imgTeste", "lida", idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Formato de hora inválido");
        }

        [Fact(DisplayName = "Email inválido - Email nulo")]
        public void CreateMensagem_ParametroInvalido_Email()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.Now;

            Action action = () => new Mensagem(data, null, "Olá mundo", "imgTeste", "lida", idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Email inválido.");
        }

        [Fact(DisplayName = "Email inválido - formato incorreto")]
        public void CreateMensagem_ParametroInvalido_EmailFormato()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.Now;

            Action action = () => new Mensagem(data, "emailinvalido", "Olá mundo", "imgTeste", "lida", idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Email inválido.");
        }

        [Fact(DisplayName = "Conteúdo inválido - vazio ou nulo")]
        public void CreateMensagem_ParametroInvalido_Conteudo_VazioOuNulo()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.Now;

            Action action = () => new Mensagem(data, "teste@gmail.com", "", "imgTeste", "lida", idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Conteúdo inválido, deve ter no máximo 500 caracteres.");
        }

        [Fact(DisplayName = "Conteúdo inválido - acima do limite")]
        public void CreateMensagem_ParametroInvalido_Conteudo_AcimaDoLimite()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.Now;
            string conteudoGrande = new string('a', 501); // 501 caracteres

            Action action = () => new Mensagem(data, "teste@gmail.com", conteudoGrande, "imgTeste", "lida", idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Conteúdo inválido, deve ter no máximo 500 caracteres.");
        }

        [Fact(DisplayName = "UID do anexo inválido - acima do limite")]
        public void CreateMensagem_ParametroInvalido_UidAnexo_AcimaDoLimite()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.Now;
            string uidAnexoGrande = new string('a', 101); // 101 caracteres

            Action action = () => new Mensagem(data, "teste@gmail.com", "Olá mundo", uidAnexoGrande, "lida", idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("UID do anexo inválido, deve ter no máximo 100 caracteres.");
        }

        [Fact(DisplayName = "Status inválido - acima do limite")]
        public void CreateMensagem_ParametroInvalido_Status_AcimaDoLimite()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.Now;
            string statusGrande = new string('a', 21); // 21 caracteres

            Action action = () => new Mensagem(data, "teste@gmail.com", "Olá mundo", "imgTeste", statusGrande, idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Status inválido, deve ter no máximo 20 caracteres.");
        }

        [Fact(DisplayName = "Status inválido - vazio ou nulo")]
        public void CreateMensagem_ParametroInvalido_Status_VazioOuNulo()
        {
            Guid idUsuario = Guid.NewGuid();
            DateTime data = DateTime.Now;

            Action action = () => new Mensagem(data, "teste@gmail.com", "Olá mundo", "imgTeste", "", idUsuario);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Status inválido, deve ter no máximo 20 caracteres.");
        }
    }
}
