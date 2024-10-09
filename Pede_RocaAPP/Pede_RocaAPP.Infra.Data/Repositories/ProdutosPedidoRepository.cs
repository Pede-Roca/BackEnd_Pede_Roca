using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class ProdutosPedidoRepository : IProdutosPedidoRepository
    {
        private ApplicationDbContext _produtosPedidoContext;

        public ProdutosPedidoRepository(ApplicationDbContext produtosPedidoContext)
        {
            _produtosPedidoContext = produtosPedidoContext;
        }

        public async Task<ProdutosPedido> AdicionarAsync(ProdutosPedido produtosPedido)
        {
            _produtosPedidoContext.Add(produtosPedido);
            await _produtosPedidoContext.SaveChangesAsync();
            return produtosPedido;
        }

        public async Task<ProdutosPedido> AtualizarAsync(Guid id, ProdutosPedido produtosPedido)
        {
            var existingEntity = await _produtosPedidoContext.ProdutosPedidos.FindAsync(id);

            if (existingEntity != null)
            {
                _produtosPedidoContext.Entry(existingEntity).State = EntityState.Detached;
            }

            _produtosPedidoContext.Entry(produtosPedido).State = EntityState.Modified;
            await _produtosPedidoContext.SaveChangesAsync();

            return produtosPedido;
        }

        public async Task<ProdutosPedido> DeleteAsync(ProdutosPedido produtosPedido)
        {
            _produtosPedidoContext.Remove(produtosPedido);
            await _produtosPedidoContext.SaveChangesAsync();
            return produtosPedido;
        }

        public async Task<ProdutosPedido> GetByIdAsync(Guid id)
        {
            var produtosPedido = await _produtosPedidoContext.ProdutosPedidos.FindAsync(id);
            return produtosPedido;
        }

        public async Task<ProdutosPedido> GetByIdUpdateAsync(Guid id)
        {
            return await _produtosPedidoContext.ProdutosPedidos
                .AsNoTracking() // Não rastrear a entidade
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<ProdutosPedido>> GetAllAsync()
        {
            return await _produtosPedidoContext.ProdutosPedidos.OrderBy(p => p.Id).ToListAsync();
        }
    }
}