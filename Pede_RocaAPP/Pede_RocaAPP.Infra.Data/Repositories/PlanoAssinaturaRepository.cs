using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class PlanoAssinaturaRepository : IPlanoAssinaturaRepository
    {
        private ApplicationDbContext _planoAssinaturaContext;

        public PlanoAssinaturaRepository(ApplicationDbContext planoAssinaturaContext)
        {
            _planoAssinaturaContext = planoAssinaturaContext;
        }

        public async Task<PlanoAssinatura> AdicionarAsync(PlanoAssinatura planoAssinatura)
        {
            _planoAssinaturaContext.Add(planoAssinatura);
            await _planoAssinaturaContext.SaveChangesAsync();
            return planoAssinatura;
        }

        public async Task<PlanoAssinatura> AtualizarAsync(Guid id, PlanoAssinatura planoAssinatura)
        {
            _planoAssinaturaContext.Update(planoAssinatura);
            await _planoAssinaturaContext.SaveChangesAsync();
            return planoAssinatura;
        }

        public async Task<PlanoAssinatura> DeleteAsync(PlanoAssinatura planoAssinatura)
        {
            _planoAssinaturaContext.Remove(planoAssinatura);
            await _planoAssinaturaContext.SaveChangesAsync();
            return planoAssinatura;
        }

        public async Task<PlanoAssinatura> GetByIdAsync(Guid id)
        {
            var planoAssinatura = await _planoAssinaturaContext.planoAssinaturas.FindAsync(id);
            return planoAssinatura;
        }

        public async Task<PlanoAssinatura> GetByIdUpdateAsync(Guid id)
        {
            return await _planoAssinaturaContext.planoAssinaturas
                .AsNoTracking() // Não rastrear a entidade
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<PlanoAssinatura>> GetAllAsync()
        {
            return await _planoAssinaturaContext.planoAssinaturas.OrderBy(c => c.Id).ToListAsync();
        }


    }
}
