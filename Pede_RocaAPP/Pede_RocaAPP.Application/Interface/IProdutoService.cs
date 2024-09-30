using Pede_RocaAPP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IProdutoService
    {
        Task AdicionarAsync(ProdutoDTO produtoDTO);
        Task AtualizarAsync(Guid id, ProdutoDTO produtoDTO);
        Task DeleteAsync(Guid id);
        Task<ProdutoDTO> GetByIdAsync(Guid id);
        Task<IEnumerable<ProdutoDTO>> GetAllAsync();
    }
}
