using BackEnd.Domain.IRepository;
using BackEnd.Domain.Model;
using BackEnd.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public LoginRepository(ApplicationDBContext dBContext)
        {
            _dBContext= dBContext;
        }
        public async Task<Usuario> Login(Usuario usuario)
        {
            var User = await _dBContext.Usuarios.FirstOrDefaultAsync(user=> user.NombreUsuario == usuario.NombreUsuario && user.Password == usuario.Password);
            return User;
        }
    }
}
