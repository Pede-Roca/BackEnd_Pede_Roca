using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AdicionarAsync(CategoriaCreateDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.AdicionarAsync(categoriaEntity);
            return categoriaEntity.Id;
        }

        public async Task AtualizarAsync(Guid id, CategoriaCreateDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.AtualizarAsync(id, categoriaEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var categoriaEntity = await _categoriaRepository.GetByIdAsync(id);
            await _categoriaRepository.DeleteAsync(categoriaEntity);
        }

        public async Task<CategoriaDTO> GetByIdAsync(Guid id)
        {
            var categoriaEntity = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoriaEntity);
        }

        public async Task<CategoriaCreateDTO> GetByIdUpdateAsync(Guid id)
        {
            var categoriaEntity = await _categoriaRepository.GetByIdUpdateAsync(id);
            return _mapper.Map<CategoriaCreateDTO>(categoriaEntity);

        }

        public async Task<IEnumerable<Produto>> GetByCategoriaIdAsync(Guid id)
        {
            return await _categoriaRepository.GetByCategoriaIdAsync(id);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            var categoriaEntity = await _categoriaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriaEntity);
        }

    }
}
