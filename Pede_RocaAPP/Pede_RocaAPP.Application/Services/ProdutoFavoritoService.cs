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

        public async Task<Guid> AdicionarAsync(ProdutoFavoritoCreateDTO produtoFavoritoDTO)
        {
            var produtoFavorito = _mapper.Map<ProdutoFavorito>(produtoFavoritoDTO);
            await _produtoFavoritoRepository.AdicionarAsync(produtoFavorito);
            return produtoFavorito.Id;
        }

        public async Task AtualizarAsync(Guid id, ProdutoFavoritoCreateDTO produtoFavoritoDto)
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

        public async Task<ProdutoFavoritoCreateDTO> GetByIdUpdateAsync(Guid id)
        {
            var produtoFavorito = await _produtoFavoritoRepository.GetByIdUpdateAsync(id);
            return _mapper.Map<ProdutoFavoritoCreateDTO>(produtoFavorito);
        }

        public async Task<ProdutoFavoritoDTO> GetByIdAndUserIdAsync(Guid id, Guid userId)
        {
            var produtoFavorito = await _produtoFavoritoRepository.GetByIdAndUserIdAsync(id, userId);
            return _mapper.Map<ProdutoFavoritoDTO>(produtoFavorito);
        }

        public async Task<IEnumerable<ProdutoFavoritoDTO>> GetAllAsync()
        {
            var produtosFavoritos = await _produtoFavoritoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoFavoritoDTO>>(produtosFavoritos);
        }

        public async Task<IEnumerable<ProdutoFavoritoDTO>> GetAllByUserId(Guid clienteId)
        {
            var produtosFavoritos = await _produtoFavoritoRepository.GetAllByUserIdAsync(clienteId);
            return _mapper.Map<IEnumerable<ProdutoFavoritoDTO>>(produtosFavoritos);
        }
    }
}
