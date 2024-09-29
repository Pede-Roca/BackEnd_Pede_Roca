using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Application.DTOs
{
    public class CategoriaDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
