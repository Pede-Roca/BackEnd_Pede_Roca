using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Interface
{
    public interface ICarrinhoCompraService
    {
        Task<Guid> AdicionarAsync(CarrinhoCompraCreateDTO carrinhoCompraDTO);
        Task AdicionarProdutoNoCarrinho(CarrinhoComprasProdutosPedidoDTO carrinhoComprasProdutosPedido);
        Task AtualizarAsync(Guid id, CarrinhoCompraDTO carrinhoCompraDTO);
        Task RemoverProdutoDoCarrinhoAsync(Guid idCarrinhoCompra, Guid idProdutoPedido);
        Task<FinalizarCompraResponse> FinalizarCompraDoCarrinhoAsync(Guid idCarrinhoCompra, CarrinhoCompra carrinhoCompra);
        Task DeleteAsync(Guid id);
        Task<CarrinhoCompraDTO> GetByIdAsync(Guid id);
        Task<CarrinhoCompraDTO> GetByIdUsuarioAsync(Guid id);
        Task<CarrinhoCompraDTO> GetHistoricoByIdUsuarioAsync(Guid id);
        Task<CarrinhoCompraDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<CarrinhoCompraDTO>> GetAllAsync();
        Task<IEnumerable<ItensCarrinhoCompraDTO>> GetProdutosNoCarrinhoCompra(Guid idUsuario);
    }
}