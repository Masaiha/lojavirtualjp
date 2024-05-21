using AutoMapper;
using FM.lojavirtual.Application.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Interfaces.Domain;

namespace FM.lojavirtual.Application.Servicos
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _service.Listar());
        }
    }
}
