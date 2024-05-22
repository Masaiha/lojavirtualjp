using AutoMapper;
using FM.lojavirtual.Application.Interfaces;
using FM.lojavirtual.Application.ViewModels;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace FM.lojavirtual.Application.Servicos
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ILoginRepository _repository;
        private readonly IMapper _mapper;

        public LoginAppService(ILoginRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioViewModel?> Autenticar(string login, string senha)
        {
            return _mapper.Map<UsuarioViewModel>(await _repository.Autenticar(login, senha));
        }
    }
}
