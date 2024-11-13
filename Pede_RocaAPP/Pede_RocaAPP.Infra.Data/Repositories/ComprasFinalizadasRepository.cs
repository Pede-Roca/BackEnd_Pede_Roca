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
            var query = from cf in _context.ComprasFinalizadas
                        join cc in _context.CarrinhoCompras on cf.IdCarrinhoCompra equals cc.Id
                        orderby cf.Data
                        select new ComprasFinalizadas
                        {
                            Id = cf.Id,
                            Data = cf.Data,
                            Status = cf.Status,
                            DataEntrega = cf.DataEntrega,
                            IdCarrinhoCompra = cf.IdCarrinhoCompra,
                            IdEndereco = cf.IdEndereco,
                            TipoEntrega = cf.TipoEntrega,
                            TipoPagamento = cf.TipoPagamento,
                            // Aqui você pode mapear o IdUsuario, por exemplo, se ele não for parte de ComprasFinalizadas:
                            IdUsuario = cc.IdUsuario
                        };

            return await query.ToListAsync();
        }


        public async Task<ComprasFinalizadas> DeleteAsync(ComprasFinalizadas finalizadas)
        {
            _context.Remove(finalizadas);
            await _context.SaveChangesAsync();
            return finalizadas;
        }
    }
}
