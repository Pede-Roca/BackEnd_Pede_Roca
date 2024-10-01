using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private ApplicationDbContext _avaliacaoContext;

        public AvaliacaoRepository(ApplicationDbContext context)
        {
            _avaliacaoContext = context;
        }

        public async Task<Avaliacao> AdicionarAsync(Avaliacao avaliacao)
        {
            _avaliacaoContext.Add(avaliacao);
            await _avaliacaoContext.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<Avaliacao> AtualizarAsync(Guid id, Avaliacao avaliacao)
        {
            _avaliacaoContext.Update(avaliacao);
            await _avaliacaoContext.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<Avaliacao> DeleteAsync(Avaliacao avaliacao)
        {
            _avaliacaoContext.Remove(avaliacao);
            await _avaliacaoContext.SaveChangesAsync();
            return avaliacao;
        }

        public async Task<Avaliacao> GetByIdAsync(Guid id)
        {
            var avaliacao = await _avaliacaoContext.Avaliacoes.FindAsync(id);
            return avaliacao;
        }

        public async Task<IEnumerable<Avaliacao>> GetAllAsync()
        {
            return await _avaliacaoContext.Avaliacoes.OrderBy(a => a.Nota).ToListAsync();
        }
    }
}