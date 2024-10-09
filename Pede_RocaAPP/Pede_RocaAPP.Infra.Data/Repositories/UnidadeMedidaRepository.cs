using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class UnidadeMedidaRepository : IUnidadeMedidaRepository
    {
        private ApplicationDbContext _unidadeMedidaContext;

        public UnidadeMedidaRepository(ApplicationDbContext context)
        {
            _unidadeMedidaContext = context;
        }

        public async Task<UnidadeMedida> AdicionarAsync(UnidadeMedida unidadeMedida)
        {
            _unidadeMedidaContext.Add(unidadeMedida);
            await _unidadeMedidaContext.SaveChangesAsync();
            return unidadeMedida;
        }

        public async Task<UnidadeMedida> AtualizarAsync(Guid id, UnidadeMedida unidadeMedida)
        {
            var existingEntity = await _unidadeMedidaContext.UnidadeMedidas.FindAsync(id);

            if (existingEntity != null)
            {
                _unidadeMedidaContext.Entry(existingEntity).State = EntityState.Detached;
            }

            _unidadeMedidaContext.Entry(unidadeMedida).State = EntityState.Modified;
            await _unidadeMedidaContext.SaveChangesAsync();

            return unidadeMedida;
        }

        public async Task<UnidadeMedida> DeleteAsync(UnidadeMedida unidadeMedida)
        {
            _unidadeMedidaContext.Remove(unidadeMedida);
            await _unidadeMedidaContext.SaveChangesAsync();
            return unidadeMedida;
        }

        public async Task<UnidadeMedida> GetByIdAsync(Guid id)
        {
            var unidadeMedida = await _unidadeMedidaContext.UnidadeMedidas.FindAsync(id);
            return unidadeMedida;
        }

        public async Task<UnidadeMedida> GetByIdUpdateAsync(Guid id)
        {
            return await _unidadeMedidaContext.UnidadeMedidas
                .AsNoTracking() // Não rastrear a entidade
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<UnidadeMedida>> GetAllAsync()
        {
            return await _unidadeMedidaContext.UnidadeMedidas.OrderBy(c => c.NomeUnidade).ToListAsync();
        }
    }
}
