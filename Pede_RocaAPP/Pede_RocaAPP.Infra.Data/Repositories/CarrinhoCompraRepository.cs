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
            var idProdutoQueDeseja = await _context.ProdutosPedidos
                .FirstOrDefaultAsync(p => p.Id == carrinhoComprasProdutosPedido.IdProdutosPedido);

            if (idProdutoQueDeseja == null) throw new Exception("Produto não encontrado");

            var produtoExistenteNoCarrinho = await (from ccpp in _context.CarrinhoComprasProdutosPedidos
                                                    join cc in _context.CarrinhoCompras on ccpp.IdCarrinhoCompra equals cc.Id
                                                    join pp in _context.ProdutosPedidos on ccpp.IdProdutosPedido equals pp.Id
                                                    where cc.Id == carrinhoComprasProdutosPedido.IdCarrinhoCompra
                                                          && pp.IdProduto == idProdutoQueDeseja.IdProduto
                                                    select new CarrinhoComprasProdutosPedido
                                                    {
                                                        Id = ccpp.IdProdutosPedido,
                                                        IdCarrinhoCompra = cc.Id,
                                                        IdProdutosPedido = ccpp.IdProdutosPedido,
                                                    }).FirstOrDefaultAsync();

            if (produtoExistenteNoCarrinho != null)
            {
                // Verificar se o produto encontrado no carrinho é o mesmo
                var produtosPedidosExistente = await _context.ProdutosPedidos
                    .FirstOrDefaultAsync(p => p.Id == produtoExistenteNoCarrinho.IdProdutosPedido);

                if (produtosPedidosExistente == null) throw new Exception("Produto Pedido não encontrado");

                // Atualiza a quantidade do produto
                produtosPedidosExistente.QuantidadeProduto += idProdutoQueDeseja.QuantidadeProduto;
                _context.ProdutosPedidos.Update(produtosPedidosExistente);
            }
            else
            {
                // Adiciona o produto ao carrinho se não existir
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

        public async Task<CarrinhoCompra> RemoverProdutoDoCarrinhoAsync(Guid idCarrinhoCompra, Guid idProdutoPedido)
        {
            var produtoExistenteNoCarrinho = await _context.CarrinhoComprasProdutosPedidos
                .FirstOrDefaultAsync(c => c.IdCarrinhoCompra == idCarrinhoCompra
                                          && c.IdProdutosPedido == idProdutoPedido);

            if (produtoExistenteNoCarrinho != null)
            {
                _context.CarrinhoComprasProdutosPedidos.Remove(produtoExistenteNoCarrinho);
            }

            await _context.SaveChangesAsync();

            return null;
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
                .FirstOrDefaultAsync(a => a.IdUsuario == id && a.Status);
            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> GetHistoricoByIdUsuarioAsync(Guid id)
        {
            var carrinhoCompra = await _context.CarrinhoCompras
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.IdUsuario == id && a.Status == false);
            return carrinhoCompra;
        }

        public async Task<CarrinhoCompra> GetByIdUpdateAsync(Guid id)
        {

            return await _context.CarrinhoCompras
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<CarrinhoCompra>> GetAllAsync()
        {
            return await _context.CarrinhoCompras
                .Where(c => c.Status)  // Filtra apenas os carrinhos que est�o ativos
                .OrderBy(c => c.Data)   // Ordena pela data
                .ToListAsync();
        }

        public async Task<IEnumerable<ItensCarrinhoCompra>> GetProdutosNoCarrinhoCompra(Guid idUsuario, Guid idCarrinho)
        {
            var query = from ccpp in _context.CarrinhoComprasProdutosPedidos
                        join cc in _context.CarrinhoCompras on ccpp.IdCarrinhoCompra equals cc.Id
                        join pp in _context.ProdutosPedidos on ccpp.IdProdutosPedido equals pp.Id
                        join p in _context.Produtos on pp.IdProduto equals p.Id
                        where cc.IdUsuario == idUsuario && cc.Id == idCarrinho
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

        public async Task<IEnumerable<ItemCarrinho>> GetItensCarrinhoPorIdCarrinhoAsync(Guid idCarrinhoCompra)
        {
            var query = from ccpp in _context.CarrinhoComprasProdutosPedidos
                        join pp in _context.ProdutosPedidos on ccpp.IdProdutosPedido equals pp.Id
                        join p in _context.Produtos on pp.IdProduto equals p.Id
                        where ccpp.IdCarrinhoCompra == idCarrinhoCompra
                        select new ItemCarrinho
                        {
                            IdCarrinhoCompra = ccpp.IdCarrinhoCompra,
                            IdProduto = p.Id,
                            QuantidadeComprada = pp.QuantidadeProduto,
                            EstoqueProduto = p.Estoque
                        };

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Top10ProdutosMaisVendidos>> GetTop10ProdutosMaisVendidos()
        {
            var query = from ccpp in _context.CarrinhoComprasProdutosPedidos
                        join pp in _context.ProdutosPedidos on ccpp.IdProdutosPedido equals pp.Id
                        join p in _context.Produtos on pp.IdProduto equals p.Id
                        group new { p, pp } by new { p.Id, p.Nome } into g
                        orderby g.Sum(x => x.pp.QuantidadeProduto) descending
                        select new Top10ProdutosMaisVendidos
                        {
                            IdProduto = g.Key.Id,
                            NomeProduto = g.Key.Nome,
                            QuantidadeVendida = g.Sum(x => x.pp.QuantidadeProduto),
                            ValorTotal = g.Sum(x => x.pp.QuantidadeProduto * x.p.Preco)
                        };

            return await query.Take(10).ToListAsync();
        }
    }
}