using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IMensagemService
    {
        Task<Guid> AdicionarAsync(MensagemCreateDTO mensagemDTO);
        Task AtualizarAsync(Guid id, MensagemUpdateDTO mensagemDTO);
        Task DeleteAsync(Guid id);
        Task<MensagemDTO> GetByIdAsync(Guid id);
        Task<MensagemUpdateDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<MensagemDTO>> GetAllAsync();
    }
}