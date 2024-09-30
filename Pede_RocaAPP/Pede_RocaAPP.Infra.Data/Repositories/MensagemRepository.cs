using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class MensagemRepository
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
            _mensagemContext.Update(mensagem);
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

        public async Task<IEnumerable<Mensagem>> GetAllAsync()
        {
            return await _mensagemContext.Mensagems.OrderBy(e => e.Conteudo).ToListAsync();
        }
    }
}