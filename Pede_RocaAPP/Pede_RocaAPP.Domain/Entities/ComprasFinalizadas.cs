namespace Pede_RocaAPP.Domain.Entities
{
    public class ComprasFinalizadas
    {
        public Guid Id { get; set; }
        public DateTime Data {  get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool Status { get; set; }
        public int TipoEntrega { get; set; }
        public int TipoPagamento { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public Guid IdCarrinhoCompra {  get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; }

        public ComprasFinalizadas() { }

        public ComprasFinalizadas(int tipoEntrega, int tipoPagamento, Guid idEndereco, Guid idCarrinhoCompra, Guid idUsuario)
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
            DataEntrega = null;
            Status = true;
            TipoEntrega = tipoEntrega;
            TipoPagamento = tipoPagamento;
            IdEndereco = idEndereco;
            IdCarrinhoCompra = idCarrinhoCompra;
            IdUsuario = idUsuario;
        }
    }
}
