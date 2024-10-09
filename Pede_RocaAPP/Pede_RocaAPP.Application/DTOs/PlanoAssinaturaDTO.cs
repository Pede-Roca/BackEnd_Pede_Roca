using Pede_RocaAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pede_RocaAPP.Application.DTOs
{
    public class PlanoAssinaturaDTO
    {
        public Guid id {  get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Preço")]
        public decimal preco { get; set; }
        
        [Required(ErrorMessage = "O status do plano é obrigatório")]
        [DisplayName("Status")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        [DisplayName("ID do Usuário")]
        public Guid idUsuario { get; set; }
    }

    public class PlanoAssinaturaCreateDTO
    {
        [JsonIgnore]
        public Guid id { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Preço")]
        public decimal preco { get; set; }

        [Required(ErrorMessage = "O status do plano é obrigatório")]
        [DisplayName("Status")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        [DisplayName("ID do Usuário")]
        public Guid idUsuario { get; set; }
    }

    public class PlanoAssinaturaUpdateDTO
    {
        [JsonIgnore]
        public Guid id { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Preço")]
        public decimal preco { get; set; }

        [Required(ErrorMessage = "O status do plano é obrigatório")]
        [DisplayName("Status")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        [DisplayName("ID do Usuário")]
        [JsonIgnore]
        public Guid idUsuario { get; set; }
    }
}
