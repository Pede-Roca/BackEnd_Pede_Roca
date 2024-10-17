using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.DTOs
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser um endereço de e-mail válido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Phone(ErrorMessage = "O telefone deve ser um número de telefone válido.")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        [DisplayName("Status")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "O nível de acesso é obrigatório.")]
        [DisplayName("Nível de Acesso")]
        public string NivelAcesso { get; set; }

        [DisplayName("Foto de Perfil")]
        public string UidFotoPerfil { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Criação da Conta")]
        public DateTime CreateUserDate { get; set; }

        // public List<Endereco> Enderecos { get; set; }
    }

    public class UsuarioCreateDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser um endereço de e-mail válido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Phone(ErrorMessage = "O telefone deve ser um número de telefone válido.")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "O status é obrigatório.")]
        [DisplayName("Status")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "O nível de acesso é obrigatório.")]
        [DisplayName("Nível de Acesso")]
        public string NivelAcesso { get; set; }

        [DisplayName("Foto de Perfil")]
        public string UidFotoPerfil { get; set; }

        [JsonIgnore]
        [DataType(DataType.Date)]
        [DisplayName("Data de Criação da Conta")]
        public DateTime CreateUserDate { get; set; }

        // public List<Endereco> Enderecos { get; set; }
    }

    public class UsuarioUpdateProfilePictureDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser um endereço de e-mail válido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [JsonIgnore]
        [Phone(ErrorMessage = "O telefone deve ser um número de telefone válido.")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve ter 11 dígitos.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [JsonIgnore]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "O status é obrigatório.")]
        [DisplayName("Status")]
        public bool Status { get; set; }

        [JsonIgnore]
        [Required(ErrorMessage = "O nível de acesso é obrigatório.")]
        [DisplayName("Nível de Acesso")]
        public string NivelAcesso { get; set; }

        [DisplayName("Foto de Perfil")]
        public string UidFotoPerfil { get; set; }

        [JsonIgnore]
        [DataType(DataType.Date)]
        [DisplayName("Data de Criação da Conta")]
        public DateTime CreateUserDate { get; set; }
    }
}