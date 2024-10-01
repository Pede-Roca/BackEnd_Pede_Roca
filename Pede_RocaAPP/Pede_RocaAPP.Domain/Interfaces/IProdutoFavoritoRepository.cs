using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IProdutoFavoritoRepository
    {
        Task<ProdutoFavorito> AdicionarAsync(ProdutoFavorito produtoFavorito);
        Task<ProdutoFavorito> AtualizarAsync(Guid id, ProdutoFavorito produtoFavorito);
        Task<ProdutoFavorito> DeleteAsync(ProdutoFavorito produtoFavorito);
        Task<ProdutoFavorito> GetByIdAsync(Guid id);
        Task<IEnumerable<ProdutoFavorito>> GetAllAsync();
    }
}
