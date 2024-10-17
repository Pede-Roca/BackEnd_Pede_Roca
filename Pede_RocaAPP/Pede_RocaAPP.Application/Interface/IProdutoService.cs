using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IProdutoService
    {
        Task<Guid> AdicionarAsync(ProdutoCreateDTO produtoDTO);
        Task AtualizarAsync(Guid id, ProdutoCreateDTO produtoDTO);
        Task AtualizarStatusProdutoAsync(Guid id, bool status);
        Task DeleteAsync(Guid id);
        Task<ProdutoDTO> GetByIdAsync(Guid id);
        Task<ProdutoCreateDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<ProdutoDTO>> GetAllAsync();
        Task<IEnumerable<ProdutoDTO>> GetProdutosSemEstoqueAsync();
    }
}
