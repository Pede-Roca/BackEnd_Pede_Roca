using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public decimal Preco { get; set; }

        public bool Status { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O estoque deve ser um valor positivo.")]
        public int Estoque { get; set; }

        [Range(0, 1, ErrorMessage = "O fator promocional deve ser entre 0 e 1.")]
        public decimal FatorPromocao { get; set; }

        [Required(ErrorMessage = "O UID da foto é obrigatório.")]
        [StringLength(250, ErrorMessage = "O UID da foto deve ter no máximo 250 caracteres.")]
        public string UidFoto { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public Guid IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "A unidade de medida é obrigatória.")]
        public Guid IdUnidade { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

        public ICollection<ProdutosPedido> ProdutosPedidos { get; set; } = new List<ProdutosPedido>();
        public ICollection<ProdutoFavorito> ProdutosFavoritos { get; set; } = new List<ProdutoFavorito>();

        public Produto()
        {
        }

        public Produto(string nome, string descricao, decimal preco, bool status, int estoque, decimal fatorPromocional, string uidFoto, Guid idCategoria, Guid idUnidade)
        {
            Id = Guid.NewGuid();
            ValidateDomain(nome, descricao, preco, estoque, fatorPromocional, uidFoto, idCategoria, idUnidade);
        }

        private void ValidateDomain(string nome, string descricao, decimal preco, int estoque, decimal fatorPromocional, string uidFoto, Guid idCategoria, Guid idUnidade)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length > 100)
                throw new ArgumentException("Nome inválido.");

            if (string.IsNullOrWhiteSpace(descricao) || descricao.Length > 500)
                throw new ArgumentException("Descrição inválida.");

            if (preco < 0)
                throw new ArgumentException("Preço inválido.");

            if (estoque < 0)
                throw new ArgumentException("Estoque inválido.");

            if (fatorPromocional < 0 || fatorPromocional > 1)
                throw new ArgumentException("Fator promocional inválido.");

            if (string.IsNullOrWhiteSpace(uidFoto) || uidFoto.Length > 250)
                throw new ArgumentException("UID da foto inválido.");
        }
    }
}
