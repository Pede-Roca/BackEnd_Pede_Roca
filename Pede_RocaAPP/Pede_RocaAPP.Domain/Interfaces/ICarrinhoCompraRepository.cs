using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface ICarrinhoCompraRepository
    {
        Task<CarrinhoCompra> AdicionarAsync(CarrinhoCompra carrinhoCompra);
        Task<CarrinhoCompra> AtualizarAsync(Guid id, CarrinhoCompra carrinhoCompra);
        Task<CarrinhoCompra> DeleteAsync(CarrinhoCompra carrinhoCompra);
        Task<CarrinhoCompra> GetByIdAsync(Guid id);
        Task<CarrinhoCompra> GetByIdUpdateAsync(Guid id);

        Task<IEnumerable<CarrinhoCompra>> GetAllAsync();
    }
}