using BackEnd.Domain.Model;

namespace BackEnd.Domain.IServices
{
    public interface IUsuarioService
    {
        Task Register(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int id,string actualPassword);
        Task ChangePassword(Usuario usuario);
    }
}
