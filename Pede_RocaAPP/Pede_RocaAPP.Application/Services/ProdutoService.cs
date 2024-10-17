using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<Guid> AdicionarAsync(ProdutoCreateDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.AdicionarAsync(produto);
            return produto.Id;
        }

        public async Task AtualizarAsync(Guid id, ProdutoCreateDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.AtualizarAsync(id, produto);
        }

        public async Task AtualizarStatusProdutoAsync(Guid id, bool status)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(id);
            if (produtoExistente == null) throw new Exception("Produto não encontrado");

            produtoExistente.Status = status;
            await _produtoRepository.AtualizarAsync(id, produtoExistente);
        }

        public async Task DeleteAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            await _produtoRepository.DeleteAsync(produto);
        }

        public async Task<ProdutoDTO> GetByIdAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<ProdutoCreateDTO> GetByIdUpdateAsync(Guid id)
        {
            var produto = await _produtoRepository.GetByIdUpdateAsync(id);
            return _mapper.Map<ProdutoCreateDTO>(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosSemEstoqueAsync()
        {
            var produtos = await _produtoRepository.GetProdutosSemEstoqueAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }
    }
}
