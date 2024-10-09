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
        Task<IEnumerable<ProdutoFavoritoDTO>> GetAllAsync();
    }
}
