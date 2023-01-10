using BackEnd.Domain.Model;

namespace BackEnd.Domain.IRepository
{
    public interface ILoginRepository
    {
        public Task<Usuario> Login(Usuario usuario);
    }
}
