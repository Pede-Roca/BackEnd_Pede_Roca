using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pede_RocaAPP.Domain.Validation;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O nível de acesso é obrigatório.")]
        public string NivelAcesso { get; set; }

        public string UidFotoPerfil { get; set; }
        public bool Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateUserDate { get; set; }

        
        // Relacionamento com Avaliacao
        // public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

        // Relacionamento com CarrinhoCompra
        // public ICollection<CarrinhoCompra> CarrinhoCompra { get; set; } = new List<CarrinhoCompra>();

        // Relacionamento com Mensagem
        // public ICollection<Mensagem> Mensagens { get; set; } = new List<Mensagem>();

        // Relacionamento com PlanoAssinatura
        // public ICollection<PlanoAssinatura> PlanosAssinatura { get; set; } = new List<PlanoAssinatura>();

        // Relacionamento com ProdutoFavorito
        // public ICollection<ProdutoFavorito> ProdutosFavoritos { get; set; } = new List<ProdutoFavorito>();

        public Usuario() { }

        public Usuario(string nome, string email, string senha, string telefone, string cpf, DateTime dataNascimento, string nivelAcesso, string uidFotoPerfil, bool status, DateTime createUserDate)
        {
            Id = Guid.NewGuid();
            ValidateDomain(nome, email, senha, telefone, cpf, dataNascimento, nivelAcesso);
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            CPF = cpf;
            DataNascimento = dataNascimento;
            NivelAcesso = nivelAcesso;
            UidFotoPerfil = uidFotoPerfil;
            Status = status;
            CreateUserDate = createUserDate;
        }

        private void ValidateDomain(string nome, string email, string senha, string telefone, string cpf, DateTime dataNascimento, string nivelAcesso)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3 || nome.Length > 100, "O nome deve ter entre 3 e 100 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "O e-mail é obrigatório.");
            DomainExceptionValidation.When(!new EmailAddressAttribute().IsValid(email), "E-mail inválido.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(senha), "A senha é obrigatória.");
            DomainExceptionValidation.When(senha.Length < 6, "A senha deve ter no mínimo 6 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "O telefone é obrigatório.");
            DomainExceptionValidation.When(!new PhoneAttribute().IsValid(telefone), "Número de telefone inválido.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "O CPF é obrigatório.");
            DomainExceptionValidation.When(!System.Text.RegularExpressions.Regex.IsMatch(cpf, @"\d{11}"), "CPF inválido.");

            DomainExceptionValidation.When(dataNascimento == default, "A data de nascimento é obrigatória.");
            DomainExceptionValidation.When(dataNascimento > DateTime.Now, "A data de nascimento não pode ser no futuro.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(nivelAcesso), "O nível de acesso é obrigatório.");
        }
    }
}
