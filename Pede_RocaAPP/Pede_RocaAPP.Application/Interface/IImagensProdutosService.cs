using Pede_RocaAPP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Application.Interface
{
    public interface IImagensProdutosService
    {
        Task<Guid> AdicionarAsync(ImagensProdutosCreateDTO imagensProdutos);
        Task AtualizarAsync(Guid id, ImagensProdutosCreateDTO imagensProdutos);
        Task DeletarAsync(Guid id);
        Task<ImagensProdutosDTO> GetByIdAsync(Guid id);
        Task<ImagensProdutosCreateDTO> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<ImagensProdutosDTO>> GetAllAsync();
    }
}
