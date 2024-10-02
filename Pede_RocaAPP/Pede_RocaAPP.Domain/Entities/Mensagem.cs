using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Mensagem
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Email { get; set; }
        public string Conteudo { get; set; }
        public string UidAnexo { get; set; }
        public string Status { get; set; }

        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Mensagem()
        {
        }

        public Mensagem(Guid idUsuario, DateTime data, string email, string conteudo, string uidAnexo, string status)
        {
            Id = Guid.NewGuid();
            IdUsuario = idUsuario;
            Data = data;
            Email = email;
            Conteudo = conteudo;
            UidAnexo = uidAnexo;
            Status = status;
        }
    }
}