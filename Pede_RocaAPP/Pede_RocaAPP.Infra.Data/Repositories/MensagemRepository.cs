using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class MensagemRepository : IMensagemRepository
    {
        private ApplicationDbContext _mensagemContext;

        public MensagemRepository(ApplicationDbContext context)
        {
            _mensagemContext = context;
        }

        public async Task<Mensagem> AdicionarAsync(Mensagem mensagem)
        {
            _mensagemContext.Add(mensagem);
            await _mensagemContext.SaveChangesAsync();
            return mensagem;
        }

        public async Task<Mensagem> AtualizarAsync(Guid id, Mensagem mensagem)
        {

            var existingEntity = await _mensagemContext.Mensagems.FindAsync(id);

            if (existingEntity != null)
            {
                _mensagemContext.Entry(existingEntity).State = EntityState.Detached;
            }

            _mensagemContext.Entry(mensagem).State = EntityState.Modified;
            await _mensagemContext.SaveChangesAsync();

            return mensagem;
        }

        public async Task<Mensagem> DeleteAsync(Mensagem mensagem)
        {
            _mensagemContext.Remove(mensagem);
            await _mensagemContext.SaveChangesAsync();
            return mensagem;
        }

        public async Task<Mensagem> GetByIdAsync(Guid id)
        {
            var mensagem = await _mensagemContext.Mensagems.FindAsync(id);
            return mensagem;
        }

        public async Task<Mensagem> GetByIdUpdateAsync(Guid id)
        {
            return await _mensagemContext.Mensagems
                .AsNoTracking() // Não rastrear a entidade
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Mensagem>> GetAllAsync()
        {
            return await _mensagemContext.Mensagems.OrderBy(e => e.Conteudo).ToListAsync();
        }
    }
}