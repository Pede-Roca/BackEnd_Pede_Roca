using System;
using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Avaliacao
    {
        [Key]
        public Guid Id { get; set; }
        public int Nota { get; set; }
        public string Descricao { get; set; }

        // Chaves estrangeiras
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public Guid IdCarrinhoCompra { get; set; }
        public CarrinhoCompra CarrinhoCompra { get; set; }

        public Avaliacao()
        {
        }

        public Avaliacao(int nota, string descricao, Guid idUsuario, Guid idCarrinhoCompra)
        {
            Id = Guid.NewGuid();
            Nota = nota;
            Descricao = descricao;
            IdUsuario = idUsuario;
            IdCarrinhoCompra = idCarrinhoCompra;
        }
    }
}
