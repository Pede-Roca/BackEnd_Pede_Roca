using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class CategoriaService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.AdicionarAsync(categoria);
        }

        public async Task AtualizarAsync(Guid id, CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.AtualizarAsync(id, categoria);
        }

        public async Task DeleteAsync(Guid id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            await _categoriaRepository.DeleteAsync(id);
        }

        public async Task<CategoriaDTO> GetByIdAsync(Guid id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

    }
}
