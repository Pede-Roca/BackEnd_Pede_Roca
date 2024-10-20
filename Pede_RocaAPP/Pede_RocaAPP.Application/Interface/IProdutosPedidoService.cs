using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IProdutosPedidoService
    {
        Task<Guid> AdicionarAsync(ProdutosPedidoCreateDTO produtosPedidoDTO);
        Task AtualizarAsync(Guid id, ProdutosPedidoCreateDTO produtosPedidoDTO);
        Task AtualizarEstoqueProdutosAsync(Guid id, int quantidade, bool adicionar);
        Task DeleteAsync(Guid id);
        Task<ProdutosPedidoDTO> GetByIdAsync(Guid id);
        Task<ProdutosPedidoCreateDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<ProdutosPedidoDTO>> GetAllAsync();
    }
}
