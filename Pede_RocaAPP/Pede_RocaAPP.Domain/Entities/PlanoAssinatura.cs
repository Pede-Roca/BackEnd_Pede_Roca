namespace Pede_RocaAPP.Domain.Entities
{
    public class PlanoAssinatura
    {
        public Guid Id { get; set; }
        public decimal Preco {  get; set; }
        public bool Ativo {  get; set; }
        public Usuario IdUsuario { get; set; }

        public PlanoAssinatura()
        {
        }

        public PlanoAssinatura(Usuario idUsuario, decimal preco, bool ativo)
        {
            Id = Guid.NewGuid();
            IdUsuario = idUsuario;
            Preco = preco;
            Ativo = ativo;
        }
    }
}
