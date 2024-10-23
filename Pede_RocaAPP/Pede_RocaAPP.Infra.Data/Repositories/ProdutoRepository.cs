using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext produtoContext)
        {
            _context = produtoContext;
        }

        public async Task<Produto> AdicionarAsync(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> AtualizarAsync(Guid id, Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> AtualizarFotoProdutoAsync(Guid id, string uidFotoProduto)
        {
            var produtoExistente = await _context.Produtos.FindAsync(id);

            if (produtoExistente == null)
            {
                throw new Exception("Produto nao encontrado");
            }

            produtoExistente.UidFoto = uidFotoProduto;

            _context.Entry(produtoExistente).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return produtoExistente;
        }

        public async Task<Produto> DeleteAsync(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            return produto;
        }

        public async Task<Produto> GetByIdUpdateAsync(Guid id)
        {
            return await _context.Produtos
                .AsNoTracking() // Não rastrear a entidade
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutosSemEstoqueAsync()
        {
            return await _context.Produtos
                .AsNoTracking()
                .Where(p => p.Estoque == 0)
                .ToListAsync();
        }
    }
}
