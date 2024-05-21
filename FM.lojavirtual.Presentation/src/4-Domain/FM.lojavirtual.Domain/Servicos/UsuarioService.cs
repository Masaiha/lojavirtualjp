using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Domain;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace FM.lojavirtual.Domain.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Usuario>> Listar()
        {
            return await _repository.Listar();
        }
    }
}
