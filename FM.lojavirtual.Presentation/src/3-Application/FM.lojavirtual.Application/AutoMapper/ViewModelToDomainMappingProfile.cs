using AutoMapper;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}
