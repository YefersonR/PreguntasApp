using BackEnd.Domain.Model;

namespace BackEnd.Domain.IServices
{
    public interface ILoginService
    {
        public Task<Usuario> Login(Usuario usuario);
    }
}
