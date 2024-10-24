using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IProdutoFavoritoService
    {
        Task<Guid> AdicionarAsync(ProdutoFavoritoCreateDTO produtoFavoritoDTO);
        Task AtualizarAsync(Guid id, ProdutoFavoritoCreateDTO produtoFavorito);
        Task DeleteAsync(Guid id);
        Task<ProdutoFavoritoDTO> GetByIdAsync(Guid id);
        Task<ProdutoFavoritoCreateDTO> GetByIdUpdateAsync(Guid id);
        Task<ProdutoFavoritoDTO> GetByIdAndUserIdAsync(Guid id, Guid userId);
        Task<IEnumerable<ProdutoFavoritoDTO>> GetAllAsync();
        Task<IEnumerable<ProdutoFavoritoDTO>> GetAllByUserId(Guid clienteId);
    }
}
