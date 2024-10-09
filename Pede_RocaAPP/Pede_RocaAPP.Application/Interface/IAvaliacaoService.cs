using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IAvaliacaoService
    {
        Task<Guid> AdicionarAsync(AvaliacaoCreateDTO avaliacaoDTO);
        Task AtualizarAsync(Guid id, AvaliacaoUpdateDTO avaliacaoDTO);
        Task DeleteAsync(Guid id);
        Task<AvaliacaoDTO> GetByIdAsync(Guid id);
        Task<AvaliacaoUpdateDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<AvaliacaoDTO>> GetAllAsync();
    }
}