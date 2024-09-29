using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private ApplicationDbContext _enderecoContext;

        public EnderecoRepository(ApplicationDbContext context)
        {
            _enderecoContext = context;
        }

        public async Task<Endereco> AdicionarAsync(Endereco endereco)
        {
            _enderecoContext.Add(endereco);
            await _enderecoContext.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> AtualizarAsync(Guid id, Endereco endereco)
        {
            _enderecoContext.Update(endereco);
            await _enderecoContext.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> DeleteAsync(Endereco endereco)
        {
            _enderecoContext.Remove(endereco);
            await _enderecoContext.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> GetByIdAsync(Guid id)
        {
            var endereco = await _enderecoContext.Enderecos.FindAsync(id);
            return endereco;
        }

        public async Task<IEnumerable<Endereco>> GetAllAsync()
        {
            return await _enderecoContext.Enderecos.OrderBy(e => e.Cidade).ToListAsync();
        }
    }
}