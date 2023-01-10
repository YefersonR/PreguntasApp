using BackEnd.Domain.IRepository;
using BackEnd.Domain.Model;
using BackEnd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Repositories
{
    public class CuestionarioRepository : ICuestionarioRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public CuestionarioRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task SaveCuestionario(Cuestionario cuestionario)
        {
            await _dBContext.AddAsync(cuestionario);
            await _dBContext.SaveChangesAsync();
        }
        public async Task<List<Cuestionario>> GetListCuestionarios()
        {
             List<Cuestionario> listCuestionario = await _dBContext.Cuestionario.
                                                    Where(o=>o.Activo == true)
                                                    .Select(x=> new Cuestionario{
                                                        Id = x.Id,
                                                        Nombre  = x.Nombre,
                                                        Descripcion = x.Descripcion,
                                                        FechaCreacion = x.FechaCreacion,
                                                        Activo = x.Activo,
                                                        Usuario= new Usuario { Id = x.Usuario!.Id, NombreUsuario = x.Usuario.NombreUsuario }
                                                    })
                                                    .ToListAsync();
            return listCuestionario;
        }
        public async Task<List<Cuestionario>> GetCuestionariosByUser(int idUsuario)
        {
            List<Cuestionario> listCuestionario = await _dBContext.Cuestionario.
                                        Where(x => x.Activo == true && x.UsuarioId == idUsuario)
                                        .ToListAsync();
            return listCuestionario;
        }
        public async Task<Cuestionario> GetCuestionario(int? idCuestionario = 0)
        {
            Cuestionario cuestionario = await _dBContext.Cuestionario.
                            Where(x => x.Activo == true && x.Id == idCuestionario)
                                .Include(x => x.Preguntas)
                                        .ThenInclude(x => x.Respuestas).FirstAsync();
                          
            return cuestionario;

        }
        public async Task DeleteCuestionario(Cuestionario cuestionario)
        {
            cuestionario.Activo = false;
            _dBContext.Entry(cuestionario).State = EntityState.Modified;
            await _dBContext.SaveChangesAsync();
        }
    }
}
