using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.DTOs
{
    public class CarrinhoCompraDTO
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O Status do pedido é obrigatório.")]
        [DisplayName("Status")]
        [MaxLength(20, ErrorMessage = "O Status do pedido deve ter no máximo 20 caracteres.")]
        public string Status { get; set; }

        public Usuario IdUsuario { get; set; }

        public List<ProdutosPedido> IdProdutosPedido { get; set; }
    }
}