using Pede_RocaAPP.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Mensagem
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        [StringLength(500, ErrorMessage = "O conteúdo não pode ultrapassar 500 caracteres.")]
        public string Conteudo { get; set; }

        [StringLength(100, ErrorMessage = "O UID do anexo não pode ultrapassar 100 caracteres.")]
        public string UidAnexo { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        [StringLength(20, ErrorMessage = "O status deve ter no máximo 20 caracteres.")]
        public string Status { get; set; }

        // Chave estrangeira para Usuario
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Mensagem()
        {
        }

        public Mensagem(DateTime data, string email, string conteudo, string uidAnexo, string status, Guid idUsuario)
        {

            Id = Guid.NewGuid();
            ValidateDomain(data, email, conteudo, uidAnexo, status, idUsuario);
            Data = data;
            Email = email;
            Conteudo = conteudo;
            UidAnexo = uidAnexo;
            Status = status;
            IdUsuario = idUsuario;
        }

        private void ValidateDomain(DateTime data, string email, string conteudo, string uidAnexo, string status, Guid idUsuario)
        {
            DomainExceptionValidation.When(idUsuario == Guid.Empty, "ID de usuário inválido.");
            DomainExceptionValidation.When(data == DateTime.MinValue, "Formato de hora inválido");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email), "Email inválido.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(conteudo) || conteudo.Length > 500, "Conteúdo inválido, deve ter no máximo 500 caracteres.");
            DomainExceptionValidation.When(!string.IsNullOrEmpty(uidAnexo) && uidAnexo.Length > 100, "UID do anexo inválido, deve ter no máximo 100 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(status) || status.Length > 20, "Status inválido, deve ter no máximo 20 caracteres.");
        }
    }
}
