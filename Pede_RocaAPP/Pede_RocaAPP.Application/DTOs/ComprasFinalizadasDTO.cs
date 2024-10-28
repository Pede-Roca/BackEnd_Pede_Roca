using Pede_RocaAPP.Domain.Entities;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Pede_RocaAPP.Application.DTOs
{
    public class ComprasFinalizadasDTO
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Data")]        
        public DateTime Data { get; set; }
        
        [DisplayName("Status")]
        public bool Status { get; set; }

        [DisplayName("Data da Entrega")]
        public DateTime? DataEntrega { get; set; }

        [DisplayName("Tipo de Entrega")]
        public int TipoEntrega { get; set; }

        [DisplayName("Tipo de Pagamento")]
        public string TipoPagamento { get; set; }

        [DisplayName("Id do Endereço")]
        public Guid IdEndereco { get; set; }

        [DisplayName("Id do Carrinho de Compra")]
        public Guid IdCarrinhoCompra { get; set; }
    }

    public class ComprasFinalizadasCreateDTO
    {
        [JsonIgnore]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [JsonIgnore]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [JsonIgnore]
        [DisplayName("Status")]
        public bool Status { get; set; }

        [JsonIgnore]
        [DisplayName("Data da Entrega")]
        public DateTime? DataEntrega { get; set; }

        [DisplayName("Tipo de Entrega")]
        public int TipoEntrega { get; set; }

        [DisplayName("Tipo de Pagamento")]
        public string TipoPagamento { get; set; }

        [DisplayName("Id do Endereço")]
        public Guid IdEndereco { get; set; }

        [DisplayName("Id do Carrinho de Compra")]
        public Guid IdCarrinhoCompra { get; set; }
    }

    public class ComprasFinalizadasUpdateDTO
    {
        [JsonIgnore]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [JsonIgnore]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        [DisplayName("Data da Entrega")]
        public DateTime? DataEntrega { get; set; }

        [JsonIgnore]
        [DisplayName("Tipo de Entrega")]
        public int TipoEntrega { get; set; }

        [JsonIgnore]
        [DisplayName("Tipo de Pagamento")]
        public string TipoPagamento { get; set; }

        [JsonIgnore]
        [DisplayName("Id do Endereço")]
        public Guid IdEndereco { get; set; }

        [JsonIgnore]
        [DisplayName("Id do Carrinho de Compra")]
        public Guid IdCarrinhoCompra { get; set; }
    }
}
