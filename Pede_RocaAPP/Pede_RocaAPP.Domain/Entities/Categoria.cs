using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public Categoria()
        {
        }

        public Categoria(string nome)
        {
            Id = Guid.NewGuid();
            ValidateDomain(nome);
            Nome = nome;
        }

        private void ValidateDomain(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome é obrigatório.");

            if (nome.Length < 3 || nome.Length > 100)
                throw new ArgumentException("O nome deve ter entre 3 e 100 caracteres.");
        }
    }
}
