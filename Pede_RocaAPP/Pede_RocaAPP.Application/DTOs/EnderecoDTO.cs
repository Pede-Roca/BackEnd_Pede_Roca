using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Application.DTOs
{
    public class EnderecoDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [MinLength(8, ErrorMessage = "O CEP deve ter no mínimo 8 caracteres.")]
        [MaxLength(9, ErrorMessage = "O CEP deve ter no máximo 9 caracteres.")]
        [DisplayName("CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória.")]
        [MinLength(3, ErrorMessage = "A Cidade deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "A Cidade deve ter no máximo 100 caracteres.")]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [MinLength(2, ErrorMessage = "O Estado deve ter 2 caracteres.")]
        [MaxLength(2, ErrorMessage = "O Estado deve ter 2 caracteres.")]
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório.")]
        [MinLength(3, ErrorMessage = "O Logradouro deve ter no mínimo 3 caracteres.")]
        [MaxLength(150, ErrorMessage = "O Logradouro deve ter no máximo 150 caracteres.")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [Range(1, 99999, ErrorMessage = "O Número deve ser entre 1 e 99999.")]
        [DisplayName("Número")]
        public int Numero { get; set; }

        [MaxLength(150, ErrorMessage = "O Complemento deve ter no máximo 150 caracteres.")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        [DisplayName("Id do Usuario")]
        public Guid IdUsuario { get; set; }
    }
}
