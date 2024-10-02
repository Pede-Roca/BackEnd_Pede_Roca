using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class CarrinhoCompra
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }

        // Chave estrangeira para Usuario
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; } // Propriedade de navegação

        // Propriedade de navegação para ProdutosPedido
        public List<ProdutosPedido> ProdutosPedido { get; set; } = new List<ProdutosPedido>(); // Inicializando a lista

        // Propriedade de navegação para Avaliacao
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>(); // Inicializando a coleção

        public CarrinhoCompra()
        {
        }

        public CarrinhoCompra(DateTime data, string status, Guid idUsuario, List<ProdutosPedido> produtosPedido)
        {
            Id = Guid.NewGuid();
            Data = data;
            Status = status;
            IdUsuario = idUsuario;
            ProdutosPedido = produtosPedido ?? new List<ProdutosPedido>(); // Garantindo que a lista não seja nula
        }
    }
}
