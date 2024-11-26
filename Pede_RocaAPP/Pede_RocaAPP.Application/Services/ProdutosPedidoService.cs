using AutoMapper;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;

namespace Pede_RocaAPP.Application.Services
{
    public class ProdutosPedidoService : IProdutosPedidoService
    {
        private readonly IProdutosPedidoRepository _produtosPedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        private readonly IMapper _mapper;

        public ProdutosPedidoService(IProdutosPedidoRepository produtosPedidoRepository, IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtosPedidoRepository = produtosPedidoRepository;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<Guid> AdicionarAsync(ProdutosPedidoCreateDTO produtosPedidoDTO)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(produtosPedidoDTO.IdProduto);
            if (produtoExistente == null) throw new Exception("Produto não encontrado");

            produtosPedidoDTO.ValorTotal = produtoExistente.Preco * produtosPedidoDTO.QuantidadeProduto * produtoExistente.FatorPromocao;

            var produtosPedido = _mapper.Map<ProdutosPedido>(produtosPedidoDTO);
            await _produtosPedidoRepository.AdicionarAsync(produtosPedido);
            return produtosPedido.Id;
        }

        public async Task AtualizarAsync(Guid id, ProdutosPedidoCreateDTO produtosPedidoDTO)
        {
            var produtosPedido = _mapper.Map<ProdutosPedido>(produtosPedidoDTO);
            await _produtosPedidoRepository.AtualizarAsync(id, produtosPedido);
        }

        public async Task AtualizarQuantidadeProdutosAsync(Guid id, int quantidade, bool adicionar)
        {
            var produtoPedidoExistente = await _produtosPedidoRepository.GetByIdAsync(id);
            if (produtoPedidoExistente == null) throw new Exception("Produto Pedido não encontrado");

            var produtoExistente = await _produtoRepository.GetByIdAsync(produtoPedidoExistente.IdProduto);
            if (adicionar)
            {
                produtoPedidoExistente.QuantidadeProduto += quantidade;
                produtoPedidoExistente.ValorTotal = produtoPedidoExistente.QuantidadeProduto * produtoExistente.Preco * produtoExistente.FatorPromocao;
            }
            else
            {
                produtoPedidoExistente.QuantidadeProduto -= quantidade;
                if (produtoPedidoExistente.QuantidadeProduto <= 0)
                {
                    await _produtosPedidoRepository.DeleteAsync(produtoPedidoExistente);
                    return; // Apenas saia do método
                }
                produtoPedidoExistente.ValorTotal = produtoPedidoExistente.QuantidadeProduto * produtoExistente.Preco * produtoExistente.FatorPromocao;
            }

            await _produtosPedidoRepository.AtualizarAsync(id, produtoPedidoExistente);
        }

        public async Task DeleteAsync(Guid id)
        {
            var produtosPedido = await _produtosPedidoRepository.GetByIdAsync(id);
            await _produtosPedidoRepository.DeleteAsync(produtosPedido);
        }

        public async Task<ProdutosPedidoDTO> GetByIdAsync(Guid id)
        {
            var produtosPedidos = await _produtosPedidoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutosPedidoDTO>(produtosPedidos);
        }

        public async Task<ProdutosPedidoCreateDTO> GetByIdUpdateAsync(Guid id)
        {
            var produtosPedido = await _produtosPedidoRepository.GetByIdUpdateAsync(id);
            return _mapper.Map<ProdutosPedidoCreateDTO>(produtosPedido);
        }

        public async Task<IEnumerable<ProdutosPedidoDTO>> GetAllAsync()
        {
            var produtosFavoritos = await _produtosPedidoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutosPedidoDTO>>(produtosFavoritos);
        }
    }
}
