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

        [Range(1, int.MaxValue, ErrorMessage = "O número deve ser maior que zero.")]
        public int Numero { get; set; }

        public string Complemento { get; set; }

        // Chave estrangeira para Usuario
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; } // Propriedade de navegação para Usuario

        public Endereco()
        {
        }

        public Endereco(string cep, string cidade, string estado, string logradouro, int numero, string complemento, Guid idUsuario)
        {
            Id = Guid.NewGuid();
            ValidateDomain(cep, cidade, estado, logradouro, numero, idUsuario);
            Complemento = complemento;
        }

        private void ValidateDomain(string cep, string cidade, string estado, string logradouro, int numero, Guid idUsuario)
        {
            if (string.IsNullOrWhiteSpace(cep) || !System.Text.RegularExpressions.Regex.IsMatch(cep, @"\d{5}-\d{3}"))
                throw new ArgumentException("CEP inválido, deve estar no formato 00000-000.");

            if (string.IsNullOrWhiteSpace(cidade) || cidade.Length < 2 || cidade.Length > 100)
                throw new ArgumentException("A cidade deve ter entre 2 e 100 caracteres.");

            if (string.IsNullOrWhiteSpace(estado) || estado.Length != 2)
                throw new ArgumentException("O estado deve ter 2 caracteres.");

            if (string.IsNullOrWhiteSpace(logradouro) || logradouro.Length < 3 || logradouro.Length > 150)
                throw new ArgumentException("O logradouro deve ter entre 3 e 150 caracteres.");

            if (numero <= 0)
                throw new ArgumentException("O número deve ser maior que zero.");

            if (idUsuario == Guid.Empty)
                throw new ArgumentException("ID de usuário inválido.");
        }
    }
}
