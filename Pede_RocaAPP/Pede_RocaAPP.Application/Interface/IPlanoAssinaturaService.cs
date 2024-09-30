using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IPlanoAssinaturaService
    {
        Task AdicionarAsync(PlanoAssinaturaDTO planoAssinaturaDTO);
        Task AtualizarAsync(Guid id, PlanoAssinaturaDTO planoAssinaturaDTO);
        Task DeleteAsync(Guid id);
        Task<PlanoAssinaturaDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<PlanoAssinaturaDTO>> GetAllAsync();
    }
}
