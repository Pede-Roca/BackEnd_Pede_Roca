using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class PlanoAssinatura
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Preco {  get; set; }
        public bool Ativo {  get; set; }

        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public PlanoAssinatura()
        {
        }

        public PlanoAssinatura(Guid idUsuario, decimal preco, bool ativo)
        {
            Id = Guid.NewGuid();
            IdUsuario = idUsuario;
            Preco = preco;
            Ativo = ativo;
        }
    }
}
