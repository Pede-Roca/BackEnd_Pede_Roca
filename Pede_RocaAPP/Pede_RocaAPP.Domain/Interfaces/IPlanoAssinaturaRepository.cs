using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IPlanoAssinaturaRepository
    {
        Task<PlanoAssinatura> AdicionarAsync(PlanoAssinatura planoAssinatura);
        Task<PlanoAssinatura> AtualizarAsync(Guid id, PlanoAssinatura planoAssinatura);
        Task<PlanoAssinatura> DeleteAsync(PlanoAssinatura planoAssinatura);
        Task<PlanoAssinatura> GetByIdAsync(Guid id);
        Task<IEnumerable<PlanoAssinatura>> GetAllAsync();
    }
}
