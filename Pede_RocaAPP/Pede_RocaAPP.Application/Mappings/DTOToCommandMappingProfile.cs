using AutoMapper;
using Pede_RocaAPP.Application.Categorias.Commands;
using Pede_RocaAPP.Application.DTOs;


namespace Pede_RocaAPP.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            //adicioanr todos os métodos
            CreateMap<CategoriaDTO, CategoriaCreateCommand>();
            CreateMap<CategoriaDTO, CategoriaUpdateCommand>();
        }
    }
}
