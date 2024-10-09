using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IUnidadeMedidaRepository
    {
        Task<UnidadeMedida> AdicionarAsync(UnidadeMedida unidadeMedida);
        Task<UnidadeMedida> AtualizarAsync(Guid id, UnidadeMedida unidadeMedida);
        Task<UnidadeMedida> DeleteAsync(UnidadeMedida unidadeMedida);
        Task<UnidadeMedida> GetByIdAsync(Guid id);
        Task<UnidadeMedida> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<UnidadeMedida>> GetAllAsync();
    }
}
