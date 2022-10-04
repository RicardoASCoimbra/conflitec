using AutoMapper;
using Conflitec.Domain.Models;
using Conflitec.Services.ViewModels;

namespace Conflitec.Services.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //////////    MODELS      \\\\\\\\\\\\\\\///////////////     VIEWMODELS     \\\\\\\\\\\\\\\\\\\\\\            

            //Usuário
            CreateMap<Usuarios, UsuarioViewModel>();
        }
    }
}
