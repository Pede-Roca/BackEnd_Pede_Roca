using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IProdutosPedidoRepository
    {
        Task<ProdutosPedido> AdicionarAsync(ProdutosPedido produtosPedido);
        Task<ProdutosPedido> AtualizarAsync(Guid id, ProdutosPedido produtosPedido);
        Task<ProdutosPedido> DeleteAsync(ProdutosPedido produtosPedido);
        Task<ProdutosPedido> GetByIdAsync(Guid id);
        Task<ProdutosPedido> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<ProdutosPedido>> GetAllAsync();
    }
}