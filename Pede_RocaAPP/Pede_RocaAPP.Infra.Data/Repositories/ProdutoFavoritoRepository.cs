using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class ProdutoFavoritoRepository : IProdutoFavoritoRepository
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
            var existingEntity = await _produtoFavoritoContext.produtosFavoritos.FindAsync(id);

            if (existingEntity != null)
            {
                _produtoFavoritoContext.Entry(existingEntity).State = EntityState.Detached;
            }

            _produtoFavoritoContext.Entry(produtoFavorito).State = EntityState.Modified;
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

        public async Task<ProdutoFavorito> GetByIdUpdateAsync(Guid id)
        {
            return await _produtoFavoritoContext.produtosFavoritos
                .AsNoTracking() // Não rastrear a entidade
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<ProdutoFavorito>> GetAllAsync()
        {
            return await _produtoFavoritoContext.produtosFavoritos.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
