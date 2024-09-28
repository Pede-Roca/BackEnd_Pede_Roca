using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> AdicionarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Guid id, Categoria categoria);
        Task DeleteAsync(Categoria categoria);
        Task<Categoria> GetByIdAsync(Guid id);
        Task<IEnumerable<Categoria>> GetAllAsync();
    }
}
