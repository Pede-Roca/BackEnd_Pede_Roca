using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class ComprasFinalizadasRepository : IComprasFinalizadasRepository
    {
        private ApplicationDbContext _context;

        public ComprasFinalizadasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ComprasFinalizadas> AdicionarAsync(ComprasFinalizadas finalizadas)
        {
            _context.Add(finalizadas);
            await _context.SaveChangesAsync();
            return finalizadas;
        }

        public async Task<ComprasFinalizadas> AtualizarAsync(Guid id, ComprasFinalizadas finalizadas)
        {
            var existingEntity = await _context.ComprasFinalizadas.FindAsync(id);

            if (existingEntity != null) _context.Entry(existingEntity).State = EntityState.Detached;

            _context.Entry(finalizadas).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return finalizadas;
        }

        public async Task<ComprasFinalizadas> GetByIdAsync(Guid id)
        {
            var finalizadas = await _context.ComprasFinalizadas.FindAsync(id);
            return finalizadas;
        }

        public async Task<IEnumerable<ComprasFinalizadas>> GetAllAsync()
        {
            return await _context.ComprasFinalizadas.OrderBy(c => c.Data).ToListAsync();
        }

        public async Task<ComprasFinalizadas> DeleteAsync(ComprasFinalizadas finalizadas)
        {
            _context.Remove(finalizadas);
            await _context.SaveChangesAsync();
            return finalizadas;
        }
    }
}
