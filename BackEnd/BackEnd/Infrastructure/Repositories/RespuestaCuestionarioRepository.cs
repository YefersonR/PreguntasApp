using BackEnd.Domain.IRepository;
using BackEnd.Domain.Model;
using BackEnd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Repositories
{
    public class RespuestaCuestionarioRepository : IRespuestaCuestionarioRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public RespuestaCuestionarioRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task SaveRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
            respuestaCuestionario.Activo = 1;
            respuestaCuestionario.Fecha = DateTime.Now;
            await _dbContext.Set<RespuestaCuestionario>().AddAsync(respuestaCuestionario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<RespuestaCuestionario>> ListCuestionarios(int idCuestionario, int idUsuario)
        {
            return await _dbContext.Set<RespuestaCuestionario>()
                    .Where(cuestionario => cuestionario.CuestionarioId == idCuestionario && cuestionario.Activo == 1 && cuestionario.Cuestionario!.UsuarioId == idUsuario).ToListAsync();
        }
        public async Task<RespuestaCuestionario> Cuestionario(int idCuestionario, int idUsuario)
        {
            return await _dbContext.Set<RespuestaCuestionario>()
                .Where(x => x.Id == idCuestionario && x.Activo == 1 && x.Cuestionario!.UsuarioId == idUsuario).Include(x=>x.RespuestaDetalles).FirstAsync();
        }
        public async Task DeleteRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
            respuestaCuestionario.Activo = 0;
            _dbContext.Entry(respuestaCuestionario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
