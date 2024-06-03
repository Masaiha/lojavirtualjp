using AutoMapper;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Entidades;

namespace FM.lojavirtual.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Veiculo, VeiculoViewModel>();
        }
    }
}
