using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Categorias.Commands
{
    public class EnderecoCommand : IRequest<Endereco>
    {
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}