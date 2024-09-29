namespace Pede_RocaAPP.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NivelAcesso { get; set; }
        public string UidFotoPerfil { get; set; }
        public bool Status { get; set; }
        public DateTime CreateUserDate { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public Usuario()
        {
        }

        public Usuario(string nome, string email, string senha, string telefone, string cpf, DateTime dataNascimento, string nivelAcesso, string uidFotoPerfil, bool status, DateTime createUserDate)
        {
            Id = Guid.NewGuid();
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
            Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
            CPF = cpf ?? throw new ArgumentNullException(nameof(cpf));
            DataNascimento = dataNascimento == null ? throw new ArgumentNullException(nameof(dataNascimento)) : dataNascimento;
            NivelAcesso = nivelAcesso ?? throw new ArgumentNullException(nameof(nivelAcesso));
            UidFotoPerfil = uidFotoPerfil ?? throw new ArgumentNullException(nameof(uidFotoPerfil));
            Status = status == null ? throw new ArgumentNullException(nameof(status)) : status;
            CreateUserDate = createUserDate == null ? throw new ArgumentNullException(nameof(createUserDate)) : createUserDate;
        }
    }
}