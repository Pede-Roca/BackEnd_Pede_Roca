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
        Task AdicionarAsync(UnidadeMedidaDTO unidadeMedidaDTO);
        Task AtualizarAsync(Guid id, UnidadeMedidaDTO unidadeMedidaDTO);
        Task DeletarAscyn(Guid id);
        Task<UnidadeMedidaDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<UnidadeMedidaDTO>> GetAllAsync();
    }
}
