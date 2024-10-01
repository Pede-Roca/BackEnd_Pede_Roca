using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IAvaliacaoService
    {
        Task AdicionarAsync(AvaliacaoDTO avaliacaoDTO);
        Task AtualizarAsync(Guid id, AvaliacaoDTO avaliacaoDTO);
        Task DeleteAsync(Guid id);
        Task<AvaliacaoDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<AvaliacaoDTO>> GetAllAsync();
    }
}