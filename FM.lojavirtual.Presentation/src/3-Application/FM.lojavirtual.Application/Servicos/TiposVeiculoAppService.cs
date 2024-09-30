using AutoMapper;
using FM.lojavirtual.Application.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Interfaces.Domain;

namespace FM.lojavirtual.Application.Servicos
{
    public class TiposVeiculoAppService : ITiposVeiculoAppService
    {
        private readonly IMapper _mapper;
        private readonly ITiposVeiculoService _service;

        public TiposVeiculoAppService(ITiposVeiculoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TiposVeiculoViewModel>> Listar()
        {
            return _mapper.Map<IEnumerable<TiposVeiculoViewModel>>(await _service.Listar());
        }

        public async Task<TiposVeiculoViewModel> ObterPorID(int id)
        {
            return _mapper.Map<TiposVeiculoViewModel>(await _service.ObterPorId(id));
        }
    }
}
