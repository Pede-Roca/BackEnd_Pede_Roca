using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pede_RocaAPP.Domain.Validation;

namespace Pede_RocaAPP.Domain.Entities
{
    public class UnidadeMedida
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da unidade é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome da unidade deve ter entre 2 e 50 caracteres.")]
        public string NomeUnidade { get; set; }

        [Required(ErrorMessage = "A sigla da unidade é obrigatória.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "A sigla da unidade deve ter entre 1 e 10 caracteres.")]
        public string SiglaUnidade { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public UnidadeMedida()
        {
        }

        public UnidadeMedida(string nomeUnidade, string siglaUnidade)
        {
            ValidateDomain(nomeUnidade, siglaUnidade);
            Id = Guid.NewGuid();
            NomeUnidade = nomeUnidade;
            SiglaUnidade = siglaUnidade;
        }

        private void ValidateDomain(string nomeUnidade, string siglaUnidade)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeUnidade), 
                "O nome da unidade é obrigatório.");

            DomainExceptionValidation.When(nomeUnidade.Length < 2 || nomeUnidade.Length > 50,
                "O nome da unidade deve ter entre 2 e 50 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(siglaUnidade),
                "A sigla da unidade é obrigatória.");

            DomainExceptionValidation.When(siglaUnidade.Length < 1 || siglaUnidade.Length > 10,
                "A sigla da unidade deve ter entre 1 e 10 caracteres.");
        }
    }
}
