using Pede_RocaAPP.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pede_RocaAPP.Application.DTOs
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínomo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "A descrição é obrigatório")]
        [MinLength(5, ErrorMessage = "A descrição deve ter no mínomo 5 caracteres")]
        [MaxLength(200, ErrorMessage = "A descriçao deve ter no máximo 200 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "O Preço é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }
        
        [Required(ErrorMessage = "O Status é obrigatório.")]
        [DisplayName("Status")]
        public bool Status { get; set; }
        
        [Required(ErrorMessage = "A Quantidade em Estoque é obrigatória.")]
        [Range(0, 9999, ErrorMessage = "O Estoque deve ser entre 0 e 9999.")]
        [DisplayName("Estoque")]
        public int Estoque { get; set; }
        
        [Required(ErrorMessage = "O Fator de Promoção é obrigatório, utilize 1 para itens fora de promção.")]
        [DisplayName("Fator de Promoção")]
        public decimal FatorPromocao { get; set; }
        
        [MaxLength(250)]
        [DisplayName("Imagem do Produto")]
        public string UidFoto { get; set; }
        
        [DisplayName("Categoria")]
        public Guid IdCategoria { get; set; }

        [Required(ErrorMessage = "A Unidade de medida é obrigatória.")]
        [DisplayName("Unidade")]
        public Guid IdUnidade { get; set; }
    }

    public class ProdutoCreateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínomo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "A descrição é obrigatório")]
        [MinLength(5, ErrorMessage = "A descrição deve ter no mínomo 5 caracteres")]
        [MaxLength(200, ErrorMessage = "A descriçao deve ter no máximo 200 caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "O Preço é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }
        
        [Required(ErrorMessage = "O Status é obrigatório.")]
        [DisplayName("Status")]
        public bool Status { get; set; }
        
        [Required(ErrorMessage = "A Quantidade em Estoque é obrigatória.")]
        [Range(0, 9999, ErrorMessage = "O Estoque deve ser entre 0 e 9999.")]
        [DisplayName("Estoque")]
        public int Estoque { get; set; }
        
        [Required(ErrorMessage = "O Fator de Promoção é obrigatório, utilize 1 para itens fora de promção.")]
        [DisplayName("Fator de Promoção")]
        public decimal FatorPromocao { get; set; }
        
        [MaxLength(250)]
        [DisplayName("Imagem do Produto")]
        public string UidFoto { get; set; }
        
        [DisplayName("Categoria")]
        public Guid IdCategoria { get; set; }
        
        [Required(ErrorMessage = "A Unidade de medida é obrigatória.")]
        [DisplayName("Unidade")]
        public Guid IdUnidade { get; set; }
    }
}
