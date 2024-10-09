using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface ICarrinhoCompraService
    {
        Task<Guid> AdicionarAsync(CarrinhoCompraCreateDTO carrinhoCompraDTO);
        Task AtualizarAsync(Guid id, CarrinhoCompraDTO carrinhoCompraDTO);
        Task DeleteAsync(Guid id);
        Task<CarrinhoCompraDTO> GetByIdAsync(Guid id);
        Task<CarrinhoCompraDTO> GetByIdUpdateAsync(Guid id);

        Task<IEnumerable<CarrinhoCompraDTO>> GetAllAsync();
    }
}