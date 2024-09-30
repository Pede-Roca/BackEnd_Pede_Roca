using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> AdicionarAsync(Produto produto);
        Task<Produto> AtualizarAsync(Guid id, Produto produto);
        Task<Produto> DeleteAsync(Produto produto);
        Task<Produto> GetByIdAsync(Guid id);
        Task<IEnumerable<Produto>> GetAllAsync();
    }
}
