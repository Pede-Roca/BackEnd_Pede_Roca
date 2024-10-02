using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Status { get; set; }
        public int Estoque { get; set; }
        public decimal FatorPromocao { get; set; }
        public string UidFoto { get; set; }

        public Guid IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public Guid IdUnidade { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

        public ICollection<ProdutosPedido> ProdutosPedidos { get; set; }

        public ICollection<ProdutoFavorito> ProdutosFavoritos { get; set; }


        public Produto()
        {
        }

        public Produto(string nome, string descricao, decimal preco, bool status, int estoque, decimal fatorPromocional, string uidFoto, Guid idCategoria, Guid idUnidade)
        {
            Id = Guid.NewGuid();
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Preco = preco;
            Status = status;
            Estoque = estoque;
            FatorPromocao = fatorPromocional;
            UidFoto = uidFoto ?? throw new ArgumentNullException(nameof(uidFoto));
            IdCategoria = idCategoria;
            IdUnidade = idUnidade;
        }
    }
}
