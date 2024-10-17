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
        private ApplicationDbContext _context;

        public CarrinhoCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CarrinhoCompra> AdicionarAsync(CarrinhoCompra carrinhoCompra)
        {
            _context.Add(carrinhoCompra);
            await _context.SaveChangesAsync();
            return carrinhoCompra;
        }

        public async Task<CarrinhoComprasProdutosPedido> AdicionarProdutoNoCarrinho(CarrinhoComprasProdutosPedido carrinhoComprasProdutosPedido)
        {
            var produtoExistenteNoCarrinho = await _context.CarrinhoComprasProdutosPedidos
                .FirstOrDefaultAsync(c => c.IdCarrinhoCompra == carrinhoComprasProdutosPedido.IdCarrinhoCompra
                                          && c.IdProdutosPedido == carrinhoComprasProdutosPedido.IdProdutosPedido);

            if (produtoExistenteNoCarrinho != null)
            {
                produtoExistenteNoCarrinho.ProdutosPedido.QuantidadeProduto += carrinhoComprasProdutosPedido.ProdutosPedido.QuantidadeProduto;
                _context.CarrinhoComprasProdutosPedidos.Update(produtoExistenteNoCarrinho);
            }
            else
            {
                _context.CarrinhoComprasProdutosPedidos.Add(carrinhoComprasProdutosPedido);
            }

            await _context.SaveChangesAsync();

            return carrinhoComprasProdutosPedido;
        }

        public async Task<CarrinhoCompra> AtualizarAsync(Guid id, CarrinhoCompra carrinhoCompra)
        {
            var existingEntity = await _context.CarrinhoCompras.FindAsync(id);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Entry(carrinhoCompra).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> DeleteAsync(CarrinhoCompra carrinhoCompra)
        {
            _context.Remove(carrinhoCompra);
            await _context.SaveChangesAsync();
            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> GetByIdAsync(Guid id)
        {
            var carrinhoCompra = await _context.CarrinhoCompras.FindAsync(id);
            return carrinhoCompra;
        }
        public async Task<CarrinhoCompra> GetByIdUsuarioAsync(Guid id)
        {
            var carrinhoCompra = await _context.CarrinhoCompras
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.IdUsuario == id);
            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> GetByIdUpdateAsync(Guid id)
        {

            return await _context.CarrinhoCompras
                .AsNoTracking() // Não rastrear a entidade
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<CarrinhoCompra>> GetAllAsync()
        {
            return await _context.CarrinhoCompras
                .Where(c => c.Status)  // Filtra apenas os carrinhos que estão ativos
                .OrderBy(c => c.Data)   // Ordena pela data
                .ToListAsync();
        }

        public async Task<IEnumerable<ItensCarrinhoCompra>> GetProdutosNoCarrinhoCompra(Guid idUsuario)
        {
            var query = from ccpp in _context.CarrinhoComprasProdutosPedidos
                        join cc in _context.CarrinhoCompras on ccpp.IdCarrinhoCompra equals cc.Id
                        join pp in _context.ProdutosPedidos on ccpp.IdProdutosPedido equals pp.Id
                        join p in _context.Produtos on pp.IdProduto equals p.Id
                        where cc.IdUsuario == idUsuario
                        select new ItensCarrinhoCompra(
                            pp.Id,
                            pp.QuantidadeProduto,
                            p.Id,
                            p.Nome,
                            p.Preco,
                            p.Estoque
                        );

            return await query.ToListAsync();
        }
    }
}