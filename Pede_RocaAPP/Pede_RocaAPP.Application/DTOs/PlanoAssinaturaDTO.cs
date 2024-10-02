using Pede_RocaAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pede_RocaAPP.Application.DTOs
{
    public class PlanoAssinaturaDTO
    {
        public Guid id {  get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        [DisplayName("ID do Usuário")]
        public Usuario idUsuario { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Preço")]
        public decimal preco { get; set; }
        
        [Required(ErrorMessage = "O status do plano é obrigatório")]
        [DisplayName("Status")]
        public bool Ativo { get; set; }
    }
}
