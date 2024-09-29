using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AdicionarAsync(Endereco usuario);
        Task<Usuario> AtualizarAsync(Guid id, Usuario usuario);
        Task<Usuario> DeleteAsync(Usuario usuario);
        Task<Usuario> GetByIdAsync(Guid id);
        Task<IEnumerable<Usuario>> GetAllAsync();
    }
}