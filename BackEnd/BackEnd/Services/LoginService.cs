using BackEnd.Domain.IRepository;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Model;

namespace BackEnd.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        public LoginService(ILoginRepository repository)
        {
            _repository= repository;
        }
        public async Task<Usuario> Login(Usuario usuario)
        {
            var User = await _repository.Login(usuario);
            return User;
        }
    }
}
