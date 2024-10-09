using Pede_RocaAPP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IUnidadeMedidaService
    {
        Task<Guid> AdicionarAsync(UnidadeMedidaCreateDTO unidadeMedidaDTO);
        Task AtualizarAsync(Guid id, UnidadeMedidaCreateDTO unidadeMedidaDTO);
        Task DeletarAsync(Guid id);
        Task<UnidadeMedidaDTO> GetByIdAsync(Guid id);
        Task<UnidadeMedidaCreateDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<UnidadeMedidaDTO>> GetAllAsync();
    }
}
