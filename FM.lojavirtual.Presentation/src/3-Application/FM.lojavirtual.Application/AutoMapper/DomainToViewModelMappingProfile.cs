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
            CreateMap<Veiculo, VeiculoViewModel>()
                .ForMember(dest => dest.VeiculoImagemViewModel, opt => opt.MapFrom(src => src.VeiculoImagem))
                .ForMember(dest => dest.TiposVeiculoViewModel, opt => opt.MapFrom(src => src.TiposVeiculo));

            CreateMap<VeiculoImagem, VeiculoImagemViewModel>();
            CreateMap<TiposVeiculo, TiposVeiculoViewModel>();
        }
    }
}
