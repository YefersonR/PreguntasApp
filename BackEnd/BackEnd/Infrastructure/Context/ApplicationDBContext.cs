using BackEnd.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Context
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuestionario> Cuestionario { get; set; }
        public DbSet<Pregunta> Pregunta { get; set; }
        public DbSet<Respuesta> Respuesta{ get; set; }
        public DbSet<RespuestaCuestionario> RespuestaCuestionarios { get; set; }
        public DbSet<RespuestaCuestionarioDetalle> RespuestaCuestionarioDetalles { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {}


    }
}
