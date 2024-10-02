using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class UnidadeMedida
    {
        [Key]
        public Guid Id { get; set; }
        public string NomeUnidade { get; set; }
        public string SiglaUnidade { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public UnidadeMedida()
        {
        }

        public UnidadeMedida(string nomeUnidade, string siglaUnidade)
        {
            Id = Guid.NewGuid();
            NomeUnidade = nomeUnidade;
            SiglaUnidade = siglaUnidade;
        }
    }
}
