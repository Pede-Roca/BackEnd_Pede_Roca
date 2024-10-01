using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ApplicationDbContext _produtoContext;

        public ProdutoRepository(ApplicationDbContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public async Task<Produto> AdicionarAsync(Produto produto)
        {
            _produtoContext.Add(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> AtualizarAsync(Guid id, Produto produto)
        {
            _produtoContext.Update(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> DeleteAsync(Produto produto)
        {
            _produtoContext.Remove(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> GetByIdAsync(Guid id)
        {
            var produto = await _produtoContext.Produtos.FindAsync(id);
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _produtoContext.Produtos.OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
