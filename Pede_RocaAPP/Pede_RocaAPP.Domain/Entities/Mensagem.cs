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

        public Mensagem(Guid idUsuario, DateTime data, string email, string conteudo, string uidAnexo, string status)
        {
            Id = Guid.NewGuid();
            ValidateDomain(idUsuario, data, email, conteudo, uidAnexo, status);
        }

        private void ValidateDomain(Guid idUsuario, DateTime data, string email, string conteudo, string uidAnexo, string status)
        {
            if (idUsuario == Guid.Empty)
                throw new ArgumentException("ID de usuário inválido.");

            if (data == default(DateTime))
                throw new ArgumentException("Data inválida.");

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("Email inválido.");

            if (string.IsNullOrWhiteSpace(conteudo) || conteudo.Length > 500)
                throw new ArgumentException("Conteúdo inválido, deve ter no máximo 500 caracteres.");

            if (!string.IsNullOrEmpty(uidAnexo) && uidAnexo.Length > 100)
                throw new ArgumentException("UID do anexo inválido, deve ter no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(status) || status.Length > 20)
                throw new ArgumentException("Status inválido, deve ter no máximo 20 caracteres.");
        }
    }
}
