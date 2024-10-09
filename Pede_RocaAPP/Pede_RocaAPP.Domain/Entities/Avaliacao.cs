using System;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Avaliacao
    {
        [Key]
        public Guid Id { get; set; }

        [Range(1, 5, ErrorMessage = "A nota deve ser entre 1 e 5.")]
        public int Nota { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 500 caracteres.")]
        public string Descricao { get; set; }

        // Chaves estrangeiras
        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "O ID do carrinho de compras é obrigatório.")]
        public Guid IdCarrinhoCompra { get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; }

        public Avaliacao()
        {
        }

        public Avaliacao(int nota, string descricao, Guid idUsuario, Guid idCarrinhoCompra)
        {
            Id = Guid.NewGuid();
            ValidateDomain(nota, descricao, idUsuario, idCarrinhoCompra);
            Nota = nota;
            Descricao = descricao;
            IdUsuario = idUsuario;
            IdCarrinhoCompra = idCarrinhoCompra;
        }

        private void ValidateDomain(int nota, string descricao, Guid idUsuario, Guid idCarrinhoCompra)
        {
            if (nota < 1 || nota > 5)
                throw new ArgumentException("Nota inválida, deve estar entre 1 e 5.");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição é obrigatória.");

            if (descricao.Length < 10 || descricao.Length > 500)
                throw new ArgumentException("A descrição deve ter entre 10 e 500 caracteres.");

            if (idUsuario == Guid.Empty)
                throw new ArgumentException("ID de usuário inválido.");

            if (idCarrinhoCompra == Guid.Empty)
                throw new ArgumentException("ID de carrinho de compras inválido.");
        }
    }
}
