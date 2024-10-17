using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AdicionarAsync(Usuario usuario);
        Task<Usuario> AtualizarAsync(Guid id, Usuario usuario);
        Task<Usuario> AtualizarFotoPerfilAsync(Guid id, string uidFotoPerfil);
        Task<Usuario> DeleteAsync(Usuario usuario);
        Task<Usuario> GetByIdAsync(Guid id);
        Task<Usuario> GetByEmailAsync(string Email);
        Task<Usuario> GetByEmailESenhaAsync(string Email, string Senha);
        Task<IEnumerable<Usuario>> GetAllAsync();
    }
}