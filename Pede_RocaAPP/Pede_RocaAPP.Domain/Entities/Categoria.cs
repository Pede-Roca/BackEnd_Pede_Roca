using Pede_RocaAPP.Domain.Validation;
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

        public Categoria(Guid id, string nome)
        {
            ValidateDomain(id, nome);
        }

        private void ValidateDomain(Guid id, string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome), "O nome é obrigatório.");

            DomainExceptionValidation.When(nome.Length < 3 || nome.Length > 100, "O nome deve ter entre 3 e 100 caracteres.");

            DomainExceptionValidation.When(id == Guid.Empty, "ID da categoria inválido.");
        }
    }
}

