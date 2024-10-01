using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pede_RocaAPP.Application.DTOs;

namespace Pede_RocaAPP.Application.Interface
{
    public interface ICarrinhoCompraService
    {
        Task AdicionarAsync(CarrinhoCompraDTO carrinhoCompraDTO);
        Task AtualizarAsync(Guid id, CarrinhoCompraDTO carrinhoCompraDTO);
        Task DeleteAsync(Guid id);
        Task<CarrinhoCompraDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<CarrinhoCompraDTO>> GetAllAsync();
    }
}