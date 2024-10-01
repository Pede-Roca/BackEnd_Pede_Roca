using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Avaliacao
    {
        // Id (do tipo Guid): identificador único de avaliação.
        [Key]
        public Guid Id { get; set; }

        // Nota (do tipo int): nota atribuida pelo usuario (de 1 a 5).
        public int Nota { get; set; }

        // Descricao (do tipo string): texto descritivo da avaliação feita pelo usuário.
        public string Descricao { get; set; }

        // IdUsuario (do tipo Guid): identificador do usuario que atribuiu a nota.
        public Usuario IdUsuario { get; set; }

        // IdCarrinhoCompra (do tipo Guid): identificador do carrinho de compra.
        public CarrinhoCompra IdCarrinhoCompra { get; set; }
    }
}