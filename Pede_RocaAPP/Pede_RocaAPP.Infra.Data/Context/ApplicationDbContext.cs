using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem> Mensagems { get; set; }
        public DbSet<PlanoAssinatura> planoAssinaturas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutosPedido> ProdutosPedidos { get; set; }
        public DbSet<ProdutoFavorito> produtosFavoritos { get; set; }
        public DbSet<CarrinhoCompra> CarrinhoCompras { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<CarrinhoComprasProdutosPedido> CarrinhoComprasProdutosPedidos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
