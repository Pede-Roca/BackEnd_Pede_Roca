using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class ImagensProdutosService : IImagensProdutosService
    {
        private readonly IMapper _mapper;
        private readonly IImagensProdutosRepository _repository;

        public ImagensProdutosService(IImagensProdutosRepository imagensProdutos, IMapper mapper)
        {
            _repository = imagensProdutos;
            _mapper = mapper;
        }

        public async Task<Guid> AdicionarAsync(ImagensProdutosCreateDTO imagensProdutos)
        {
            var imagens_produtos_entity = _mapper.Map<ImagensProdutos>(imagensProdutos);
            await _repository.AdicionarAsync(imagens_produtos_entity);
            return imagens_produtos_entity.Id;
        }

        public async Task AtualizarAsync(Guid id, ImagensProdutosCreateDTO imagensProdutos)
        {
            var imagens_produtos_entity = _mapper.Map<ImagensProdutos>(imagensProdutos);
            await _repository.AtualizarAsync(id, imagens_produtos_entity);
        }

        public async Task<ImagensProdutosDTO> GetByIdAsync(Guid id)
        {
            var imagens_produtos_entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ImagensProdutosDTO>(imagens_produtos_entity);
        }

        public async Task<ImagensProdutosCreateDTO> GetByIdUpdateAsync(Guid id)
        {
            var imagensProdutos = await _repository.GetByIdUpdateAsync(id);
            return _mapper.Map<ImagensProdutosCreateDTO>(imagensProdutos);
        }

        public async Task<IEnumerable<ImagensProdutosDTO>> GetAllAsync()
        {
            var imagens_produtos_entity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ImagensProdutosDTO>>(imagens_produtos_entity);
        }

        public async Task DeletarAsync(Guid id)
        {
            var imagens_produtos_entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(imagens_produtos_entity);
        }
    }
}
