using BackEnd.Domain.IRepository;
using BackEnd.Domain.Model;
using BackEnd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEnd.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public UsuarioRepository(ApplicationDBContext dBContext) 
        {
            _dBContext = dBContext;
        }

        public async Task Register(Usuario usuario)
        {
            await _dBContext.AddAsync(usuario);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var exist = await _dBContext.Usuarios.AnyAsync(user=>user.NombreUsuario == usuario.NombreUsuario);
            return exist;
        }
        public async Task<Usuario> ValidatePassword(int id, string actualPassword)
        {
            var usuario = await _dBContext.Usuarios.Where(user=> user.Id == id && user.Password == actualPassword).FirstOrDefaultAsync();
            return usuario;
        }
        public async Task ChangePassword(Usuario usuario)
        {
            _dBContext.Update(usuario);
            await _dBContext.SaveChangesAsync();
        }
    }
}
