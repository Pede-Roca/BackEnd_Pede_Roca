using MediatR;
using Pede_RocaAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pede_RocaAPP.Application.Categorias.Commands
{
    public class CategoriaUpdateCommand : IRequest<Categoria>
    {
        public Guid Id { get; set; }
    }
}
