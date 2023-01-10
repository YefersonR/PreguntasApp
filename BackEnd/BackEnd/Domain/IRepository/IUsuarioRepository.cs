using BackEnd.Domain.Model;

namespace BackEnd.Domain.IRepository
{
    public interface IUsuarioRepository
    {
        Task Register(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int id,string actualPassword);
        Task ChangePassword(Usuario usuario);
    }
}
