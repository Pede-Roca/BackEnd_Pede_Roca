using Pede_RocaAPP.Domain.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Endereco
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "A cidade deve ter entre 2 e 100 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "O estado deve ter 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O logradouro deve ter entre 3 e 150 caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O bairro deve ter entre 3 e 150 caracteres.")]
        public string Bairro { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O número deve ser maior que zero.")]
        public int Numero { get; set; }

        [StringLength(150, ErrorMessage = "O complemento deve ter no máximo 150 caracteres.")]
        public string Complemento { get; set; }

        // Chave estrangeira para Usuario
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; } // Propriedade de navegação para Usuario

        public Endereco()
        {
        }

        public Endereco(string cep, string cidade, string estado, string logradouro, string bairro, int numero, string complemento, Guid idUsuario)
        {
            Id = Guid.NewGuid();
            ValidateDomain(cep, cidade, estado, logradouro, bairro, numero, complemento, idUsuario);
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            IdUsuario = idUsuario;
        }

        private void ValidateDomain(string cep, string cidade, string estado, string logradouro, string bairro, int numero, string complemento, Guid idUsuario)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cep) || !System.Text.RegularExpressions.Regex.IsMatch(cep, @"\d{5}-\d{3}"), "CEP inválido, deve estar no formato 00000-000.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(cidade) || cidade.Length < 2 || cidade.Length > 100, "A cidade deve ter entre 2 e 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(estado) || estado.Length != 2, "O estado deve ter 2 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(logradouro) || logradouro.Length < 3 || logradouro.Length > 150, "O logradouro deve ter entre 3 e 150 caracteres.");
            
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(bairro) || bairro.Length < 3 || bairro.Length > 150, "O bairro deve ter entre 3 e 150 caracteres.");

            DomainExceptionValidation.When(numero <= 0, "O número deve ser maior que zero.");
            
            DomainExceptionValidation.When(complemento != null && complemento.Length > 150, "O complemento deve ter no máximo 150 caracteres.");

            DomainExceptionValidation.When(idUsuario == Guid.Empty, "ID de usuário inválido.");
        }
    }
}
