using MediatR;
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Application.Enderecos.Commands
{
    public class EnderecoRemoveCommand : IRequest<Endereco>
    {
        public Guid Id { get; set; }

        public EnderecoRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}