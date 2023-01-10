using BackEnd.Domain.IRepository;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Model;

namespace BackEnd.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task Register(Usuario usuario)
        {
            await _repository.Register(usuario);
        }
        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var exits = await _repository.ValidateExistence(usuario);
            return exits;
        }
        public async Task<Usuario> ValidatePassword(int id,string actualPassword)
        {
            var usuario = await _repository.ValidatePassword(id,actualPassword);
            return usuario;
        }
        public async Task ChangePassword(Usuario usuario)
        {
            await _repository.ChangePassword(usuario);
        }
    }
}
