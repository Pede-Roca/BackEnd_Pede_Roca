using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IPlanoAssinaturaService
    {
        Task<Guid> AdicionarAsync(PlanoAssinaturaCreateDTO planoAssinaturaDTO);
        Task AtualizarAsync(Guid id, PlanoAssinaturaUpdateDTO planoAssinaturaDTO);
        Task DeleteAsync(Guid id);
        Task<PlanoAssinaturaDTO> GetByIdAsync(Guid id);
        Task<PlanoAssinaturaUpdateDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<PlanoAssinaturaDTO>> GetAllAsync();
    }
}
