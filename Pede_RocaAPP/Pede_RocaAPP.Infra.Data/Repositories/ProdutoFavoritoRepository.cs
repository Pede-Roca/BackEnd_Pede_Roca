using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class ProdutoFavoritoRepository
    {
        private ApplicationDbContext _produtoFavoritoContext;

        public ProdutoFavoritoRepository(ApplicationDbContext produtoFavoritoContext)
        {
            _produtoFavoritoContext = produtoFavoritoContext;
        }

        public async Task<ProdutoFavorito> AdicionarAsync(ProdutoFavorito produtoFavorito)
        {
            _produtoFavoritoContext.Add(produtoFavorito);
            await _produtoFavoritoContext.SaveChangesAsync();
            return produtoFavorito;
        }

        public async Task<ProdutoFavorito> AtualizarAsync(Guid id,ProdutoFavorito produtoFavorito)
        {
            _produtoFavoritoContext.Update(produtoFavorito);
            await _produtoFavoritoContext.SaveChangesAsync();
            return produtoFavorito;
        }

        public async Task<ProdutoFavorito> DeleteAsync(ProdutoFavorito produtoFavorito)
        {
            _produtoFavoritoContext.Remove(produtoFavorito);
            await _produtoFavoritoContext.SaveChangesAsync();
            return produtoFavorito;
        }
        
        public async Task<ProdutoFavorito> GetByIdAsync(Guid id)
        {
            var produtoFavorito = await _produtoFavoritoContext.produtosFavoritos.FindAsync(id);
            return produtoFavorito;
        }

        public async Task<IEnumerable<ProdutoFavorito>> GetAllAsync()
        {
            return await _produtoFavoritoContext.produtosFavoritos.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
