using AutoMapper;
using FM.lojavirtual.Application.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Interfaces.Domain;

namespace FM.lojavirtual.Application.Servicos
{
    public class VeiculoAppService : IVeiculoAppService
    {
        private readonly IVeiculoService _service;
        private readonly IMapper _mapper;

        public VeiculoAppService(IVeiculoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VeiculoViewModel>> Listar()
        {
            return _mapper.Map<IEnumerable<VeiculoViewModel>>(await _service.Listar());
        }
    }
}
