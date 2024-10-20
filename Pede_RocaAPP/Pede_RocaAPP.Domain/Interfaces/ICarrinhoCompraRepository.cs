using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoCompra> AdicionarAsync(CarrinhoCompra carrinhoCompra);
        Task<CarrinhoComprasProdutosPedido> AdicionarProdutoNoCarrinho(CarrinhoComprasProdutosPedido carrinhoComprasProdutosPedido);
        Task<CarrinhoCompra> AtualizarAsync(Guid id, CarrinhoCompra carrinhoCompra);
        Task<CarrinhoCompra> RemoverProdutoDoCarrinhoAsync(Guid idCarrinhoCompra, Guid idProdutoPedido);
        Task<CarrinhoCompra> DeleteAsync(CarrinhoCompra carrinhoCompra);
        Task<CarrinhoCompra> GetByIdAsync(Guid id);
        Task<CarrinhoCompra> GetByIdUsuarioAsync(Guid id);
        Task<CarrinhoCompra> GetHistoricoByIdUsuarioAsync(Guid id);
        Task<CarrinhoCompra> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<CarrinhoCompra>> GetAllAsync();
        Task<IEnumerable<ItensCarrinhoCompra>> GetProdutosNoCarrinhoCompra(Guid idUsuario, Guid idCarrinho);
        Task<IEnumerable<ItemCarrinho>> GetItensCarrinhoPorIdCarrinhoAsync(Guid idCarrinhoCompra);
    }
}