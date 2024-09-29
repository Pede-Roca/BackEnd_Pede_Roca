using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class UnidadeMedida
    {
        [Key]
        public Guid Id { get; set; }
        public string NomeUnidade { get; set; }
        public string SiglaUnidade { get; set; }

        public UnidadeMedida(Guid id, string nomeUnidade, string siglaUnidade)
        {
            Id = Guid.NewGuid();
            NomeUnidade = nomeUnidade;
            SiglaUnidade = siglaUnidade;
        }
    }
}
