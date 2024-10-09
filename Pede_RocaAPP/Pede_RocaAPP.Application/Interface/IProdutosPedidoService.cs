using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IProdutosPedidoService
    {
        Task AdicionarAsync(ProdutosPedidoDTO produtosPedidoDTO);
        Task AtualizarAsync(Guid id, ProdutosPedidoDTO produtosPedidoDTO);
        Task DeleteAsync(Guid id);
        Task<ProdutosPedidoDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<ProdutosPedidoDTO>> GetAllAsync();
    }
}
