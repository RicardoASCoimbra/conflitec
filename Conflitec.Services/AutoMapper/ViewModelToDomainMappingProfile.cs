using AutoMapper;
using Conflitec.Domain.Commads.Usuario;
using Conflitec.Domain.Models;
using Conflitec.Services.ViewModels;

namespace Conflitec.Services.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //////////    VIEWMODELS      \\\\\\\\\\\\\\\///////////////     MODELS      \\\\\\\\\\\\\\\\\\\\\\ 

            //Usuário
            CreateMap<UsuarioViewModel, UsuarioCreateCommand>();
            CreateMap<UsuarioViewModel, UsuarioEditCommand>();
            CreateMap<UsuarioViewModel, Usuarios>();
        }
    }
}
