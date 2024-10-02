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
        public Categoria IdCategoria { get; set; }
        public UnidadeMedida IdUnidade { get; set; }

        public ICollection<ProdutosPedido> ProdutosPedidos { get; set; }


        public Produto()
        {
        }

        public Produto(string nome, string descricao, decimal preco, bool status, int estoque, decimal fatorPromocional, string uidFoto, Categoria idCategoria, UnidadeMedida idUnidade)
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
