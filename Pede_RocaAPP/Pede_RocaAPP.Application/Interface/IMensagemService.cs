using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IMensagemService
    {
        Task AdicionarAsync(MensagemDTO mensagemDTO);
        Task AtualizarAsync(Guid id, MensagemDTO mensagemDTO);
        Task DeleteAsync(Guid id);
        Task<MensagemDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<MensagemDTO>> GetAllAsync();
    }
}