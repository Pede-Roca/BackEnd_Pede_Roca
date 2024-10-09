using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IProdutoFavoritoService
    {
        Task AdicionarAsync(ProdutoFavoritoDTO produtoFavoritoDTO);
        Task AtualizarAsync(Guid id, ProdutoFavoritoDTO produtoFavorito);
        Task DeleteAsync(Guid id);
        Task<ProdutoFavoritoDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<ProdutoFavoritoDTO>> GetAllAsync();
    }
}
