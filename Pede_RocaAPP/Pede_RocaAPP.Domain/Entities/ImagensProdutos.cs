namespace Pede_RocaAPP.Domain.Entities
{
    public class ImagensProdutos
    {
        public Guid Id { get; set; }
        public string Url { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public ImagensProdutos()
        {
        }

        public ImagensProdutos(string url)
        {
            Id = Guid.NewGuid();
            Url = url;
        }
    }
}
