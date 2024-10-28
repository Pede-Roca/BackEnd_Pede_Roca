using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IComprasFinalizadasService
    {
        Task<Guid> AdicionarAsync(ComprasFinalizadasCreateDTO finalizadasDTO);
        Task AtualizarAsync(Guid id, ComprasFinalizadasCreateDTO finalizadasDTO);
        Task<ComprasFinalizadasDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<ComprasFinalizadasDTO>> GetAllAsync();
        Task DeleteAsync(Guid id);
    }
}