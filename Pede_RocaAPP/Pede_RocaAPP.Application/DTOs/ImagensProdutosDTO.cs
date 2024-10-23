using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Application.DTOs
{
    public class ImagensProdutosDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A url é obrigatório.")]
        [MinLength(2, ErrorMessage = "A url deve ter no mínimo 2 caracteres.")]
        [MaxLength(255, ErrorMessage = "A url deve ter no máximo 255 caracteres.")]
        [DisplayName("Url")]
        public string Url { get; set; }
    }

    public class ImagensProdutosCreateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A url é obrigatório.")]
        [MinLength(2, ErrorMessage = "A url deve ter no mínimo 2 caracteres.")]
        [MaxLength(255, ErrorMessage = "A url deve ter no máximo 255 caracteres.")]
        [DisplayName("Url")]
        public string Url { get; set; }
    }
}
