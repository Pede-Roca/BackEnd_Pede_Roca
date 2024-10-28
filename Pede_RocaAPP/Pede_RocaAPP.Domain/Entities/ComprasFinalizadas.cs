namespace Pede_RocaAPP.Domain.Entities
{
    public class ComprasFinalizadas
    {
        public Guid Id { get; set; }
        public DateTime Data {  get; set; }
        public bool Status { get; set; }
        public DateTime? DataEntrega { get; set; }
        public Guid IdCarrinhoCompra {  get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; }

        public ComprasFinalizadas() { }

        public ComprasFinalizadas(DateTime data, Guid idCarrinhoCompra)
        {
            Id = Guid.NewGuid();
            Data = data;
            Status = true;
            DataEntrega = null;
            IdCarrinhoCompra = idCarrinhoCompra;
        }
    }
}
