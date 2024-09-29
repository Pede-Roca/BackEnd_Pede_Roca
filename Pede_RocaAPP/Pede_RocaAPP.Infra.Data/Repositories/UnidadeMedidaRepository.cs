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
            _unidadeMedidaContext.Update(unidadeMedida);
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
            var unidadeMedida = await _unidadeMedidaContext.unidadeMedidas.FindAsync(id);
            return unidadeMedida;

        }

        public async Task<IEnumerable<UnidadeMedida>> GetAllAsync()
        {
            return await _unidadeMedidaContext.unidadeMedidas.OrderBy(c => c.NomeUnidade).ToListAsync();
        }
    }
}
