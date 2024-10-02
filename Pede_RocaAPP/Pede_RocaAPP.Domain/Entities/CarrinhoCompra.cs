using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class CarrinhoCompra
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O status deve ter entre 3 e 50 caracteres.")]
        public string Status { get; set; }

        // Chave estrangeira para Usuario
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; } // Propriedade de navegação

        // Propriedade de navegação para ProdutosPedido
        [Required(ErrorMessage = "O carrinho de compras deve conter ao menos um produto.")]
        public List<ProdutosPedido> ProdutosPedido { get; set; } = new List<ProdutosPedido>(); // Inicializando a lista

        // Propriedade de navegação para Avaliacao
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>(); // Inicializando a coleção

        public CarrinhoCompra()
        {
        }

        public CarrinhoCompra(DateTime data, string status, Guid idUsuario, List<ProdutosPedido> produtosPedido)
        {
            Id = Guid.NewGuid();
            ValidateDomain(data, status, idUsuario, produtosPedido);
        }

        private void ValidateDomain(DateTime data, string status, Guid idUsuario, List<ProdutosPedido> produtosPedido)
        {
            if (data == default(DateTime))
                throw new ArgumentException("Data inválida.");

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("O status é obrigatório.");

            if (status.Length < 3 || status.Length > 50)
                throw new ArgumentException("O status deve ter entre 3 e 50 caracteres.");

            if (idUsuario == Guid.Empty)
                throw new ArgumentException("ID de usuário inválido.");

            if (produtosPedido == null || produtosPedido.Count == 0)
                throw new ArgumentException("O carrinho de compras deve conter ao menos um produto.");
        }
    }
}
