using System.ComponentModel.DataAnnotations;

namespace Pede_RocaAPP.Domain.Entities
{
    public class Endereco
    {
        [Key]
        public Guid Id { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public Endereco()
        {
        }

        public Endereco(string cep, string cidade, string estado, string logradouro, int numero, string complemento)
        {
            Id = Guid.NewGuid();
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
        }
    }
}