using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Domain.Interfaces
{
    public interface IImagensProdutosRepository
    {
        Task<ImagensProdutos> AdicionarAsync(ImagensProdutos imagensProdutos);
        Task<ImagensProdutos> GetByIdAsync(Guid id);
        Task<ImagensProdutos> GetByIdUpdateAsync(Guid id);
        Task<IEnumerable<ImagensProdutos>> GetAllAsync();
        Task<ImagensProdutos> AtualizarAsync(Guid id, ImagensProdutos imagensProdutos);
        Task<ImagensProdutos> DeleteAsync(ImagensProdutos imagensProdutos);
    }
}
