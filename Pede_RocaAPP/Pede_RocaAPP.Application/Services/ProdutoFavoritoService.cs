using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class ProdutoFavoritoService : IProdutoFavoritoService
    {
        private readonly IProdutoFavoritoRepository _produtoFavoritoRepository;

        private readonly IMapper _mapper;

        public ProdutoFavoritoService(IProdutoFavoritoRepository produtoFavoritoRepository, IMapper mapper)
        {
            _produtoFavoritoRepository = produtoFavoritoRepository;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(ProdutoFavoritoDTO produtoFavoritoDTO)
        {
            var produtoFavorito = _mapper.Map<ProdutoFavorito>(produtoFavoritoDTO);
            await _produtoFavoritoRepository.AdicionarAsync(produtoFavorito);
        }

        public async Task AtualizarAsync(Guid id, ProdutoFavoritoDTO produtoFavoritoDto)
        {
            var produtoFavorito = _mapper.Map<ProdutoFavorito>(produtoFavoritoDto);
            await _produtoFavoritoRepository.AtualizarAsync(id, produtoFavorito);
        }

        public async Task DeleteAsync(Guid id)
        {
            var produtoFavorito = await _produtoFavoritoRepository.GetByIdAsync(id);
            await _produtoFavoritoRepository.DeleteAsync(produtoFavorito);
        }

        public async Task<ProdutoFavoritoDTO> GetByIdAsync(Guid id)
        {
            var produtoFavorito = await _produtoFavoritoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoFavoritoDTO>(produtoFavorito);
        }

        public async Task<IEnumerable<ProdutoFavoritoDTO>> GetAllAsync()
        {
            var produtosFavoritos = await _produtoFavoritoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoFavoritoDTO>>(produtosFavoritos);
        }
    }
}
