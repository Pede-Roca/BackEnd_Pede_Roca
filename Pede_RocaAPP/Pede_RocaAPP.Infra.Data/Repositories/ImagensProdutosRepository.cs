using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class ImagensProdutosRepository : IImagensProdutosRepository
    {
        private ApplicationDbContext _context;

        public ImagensProdutosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ImagensProdutos> AdicionarAsync(ImagensProdutos imagens_produtos)
        {
            _context.Add(imagens_produtos);
            await _context.SaveChangesAsync();
            return imagens_produtos;
        }

        public async Task<ImagensProdutos> AtualizarAsync(Guid id, ImagensProdutos imagens_produtos)
        {
            var existingEntity = await _context.ImagensProdutos.FindAsync(id);

            if (existingEntity != null) _context.Entry(existingEntity).State = EntityState.Detached;

            _context.Entry(imagens_produtos).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return imagens_produtos;
        }

        public async Task<ImagensProdutos> GetByIdAsync(Guid id)
        {
            return await _context.ImagensProdutos.FindAsync(id);
        }

        public async Task<ImagensProdutos> GetByIdUpdateAsync(Guid id)
        {
            return await _context.ImagensProdutos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<ImagensProdutos>> GetAllAsync()
        {
            return await _context.ImagensProdutos.OrderBy(c => c.Url).ToListAsync();
        }

        public async Task<ImagensProdutos> DeleteAsync(ImagensProdutos imagens_produtos)
        {
            _context.Remove(imagens_produtos);
            await _context.SaveChangesAsync();
            return imagens_produtos;
        }
    }
}
