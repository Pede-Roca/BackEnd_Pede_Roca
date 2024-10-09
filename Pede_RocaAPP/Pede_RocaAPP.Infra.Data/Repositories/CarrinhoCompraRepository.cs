using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class CarrinhoCompraRepository : ICarrinhoCompraRepository
    {
        private ApplicationDbContext _carrinhoCompraContext;

        public CarrinhoCompraRepository(ApplicationDbContext context)
        {
            _carrinhoCompraContext = context;
        }

        public async Task<CarrinhoCompra> AdicionarAsync(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompraContext.Add(carrinhoCompra);
            await _carrinhoCompraContext.SaveChangesAsync();
            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> AtualizarAsync(Guid id, CarrinhoCompra carrinhoCompra)
        {
            var existingEntity = await _carrinhoCompraContext.CarrinhoCompras.FindAsync(id);


            if (existingEntity != null)
            {
                _carrinhoCompraContext.Entry(existingEntity).State = EntityState.Detached;
            }

            _carrinhoCompraContext.Entry(carrinhoCompra).State = EntityState.Modified;
            await _carrinhoCompraContext.SaveChangesAsync();

            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> DeleteAsync(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompraContext.Remove(carrinhoCompra);
            await _carrinhoCompraContext.SaveChangesAsync();
            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> GetByIdAsync(Guid id)
        {
            var carrinhoCompra = await _carrinhoCompraContext.CarrinhoCompras.FindAsync(id);
            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> GetByIdUpdateAsync(Guid id)
        {

            return await _carrinhoCompraContext.CarrinhoCompras
                .AsNoTracking() // Não rastrear a entidade
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<CarrinhoCompra>> GetAllAsync()
        {
            return await _carrinhoCompraContext.CarrinhoCompras.OrderBy(c => c.Data).ToListAsync();
        }
    }
}