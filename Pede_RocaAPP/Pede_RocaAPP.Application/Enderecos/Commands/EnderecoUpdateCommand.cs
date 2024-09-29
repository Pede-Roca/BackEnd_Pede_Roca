using MediatR;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Categorias.Commands
{
    public class EnderecoUpdateCommand : IRequest<Endereco> 
    {
        public Guid Id { get; set; }
    }
}