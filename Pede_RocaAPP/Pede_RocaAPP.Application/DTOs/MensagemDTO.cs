using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.DTOs
{
    public class MensagemDTO
{
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        [DisplayName("ID do Usuário")]
        public Usuario IdUsuario { get; set; }

        [Required(ErrorMessage = "A Data de envio é obrigatória.")]
        [DisplayName("Data de Envio")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O E-mail deve ser válido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Conteudo é obrigatória.")]
        [MinLength(5, ErrorMessage = "O Conteudo deve ter no mínimo 5 caracteres.")]
        [MaxLength(1000, ErrorMessage = "O Conteudo deve ter no máximo 1000 caracteres.")]
        [DisplayName("Conteudo")]
        public string Conteudo { get; set; }

        [DisplayName("Anexo")]
        public string Anexo { get; set; }

        [Required(ErrorMessage = "Status é obrigatório.")]
        [MinLength(4, ErrorMessage = "O Status deve ter no mínimo 4 caracteres.")]
        [MaxLength(7, ErrorMessage = "O Status deve ter no máximo 7 caracteres.")]
        [DisplayName("Status")]
        public string Status { get; set; }

    }
}