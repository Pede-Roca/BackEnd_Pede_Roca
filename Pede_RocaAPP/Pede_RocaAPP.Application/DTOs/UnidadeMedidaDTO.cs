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
    public class UnidadeMedidaDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome da Unidade é obrigatório.")]
        [MinLength(2, ErrorMessage = "O Nome da Unidade deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Nome da Unidade deve ter no máximo 100 caracteres.")]
        [DisplayName("Nome da Unidade")]
        public string NomeUnidade { get; set; }

        [Required(ErrorMessage = "A Sigla da Unidade é obrigatória.")]
        [MinLength(1, ErrorMessage = "A Sigla da Unidade deve ter no mínimo 1 caractere.")]
        [MaxLength(10, ErrorMessage = "A Sigla da Unidade deve ter no máximo 10 caracteres.")]
        [DisplayName("Sigla da Unidade")]
        public string SiglaUnidade { get; set; }
    }

    public class UnidadeMedidaCreateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome da Unidade é obrigatório.")]
        [MinLength(2, ErrorMessage = "O Nome da Unidade deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Nome da Unidade deve ter no máximo 100 caracteres.")]
        [DisplayName("Nome da Unidade")]
        public string NomeUnidade { get; set; }

        [Required(ErrorMessage = "A Sigla da Unidade é obrigatória.")]
        [MinLength(1, ErrorMessage = "A Sigla da Unidade deve ter no mínimo 1 caractere.")]
        [MaxLength(10, ErrorMessage = "A Sigla da Unidade deve ter no máximo 10 caracteres.")]
        [DisplayName("Sigla da Unidade")]
        public string SiglaUnidade { get; set; }
    }
}
