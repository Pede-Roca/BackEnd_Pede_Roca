using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pede_RocaAPP.Domain.Enums;

namespace Pede_RocaAPP.Application.DTOs
{
    public class NivelAcessoDTO
    {
        public NivelAcesso NivelAtual { get; set; }
        public List<NivelAcesso> OpcoesDisponiveis { get; set; }
    }
}