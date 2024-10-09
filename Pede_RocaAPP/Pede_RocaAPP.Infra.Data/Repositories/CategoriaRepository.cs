using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext _categoriaContext;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoriaContext = context;
        }

        public async Task<Categoria> AdicionarAsync(Categoria categoria)
        {
            _categoriaContext.Add(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> AtualizarAsync(Guid id, Categoria categoria)
        {
            var existingEntity = await _categoriaContext.Categorias.FindAsync(id);

            if (existingEntity != null)
            {
                _categoriaContext.Entry(existingEntity).State = EntityState.Detached;
            }

            _categoriaContext.Entry(categoria).State = EntityState.Modified;
            await _categoriaContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria> DeleteAsync(Categoria categoria)
        {
            _categoriaContext.Remove(categoria);
            await _categoriaContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> GetByIdAsync(Guid id)
        {
            var categoria = await _categoriaContext.Categorias.FindAsync(id);
            return categoria;
        }

        public async Task<Categoria> GetByIdUpdateAsync(Guid id)
        {
            var categoria = await _categoriaContext.Categorias.FindAsync(id);
            return categoria;
        }

        public async Task<IEnumerable<Produto>> GetByCategoriaIdAsync(Guid categoriaId)
        {
            return await _categoriaContext.Produtos
                .Where(p => p.IdCategoria == categoriaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _categoriaContext.Categorias.OrderBy(c => c.Nome).ToListAsync();
        }
    }
}
