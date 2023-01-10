using BackEnd.Domain.Model;

namespace BackEnd.Domain.IRepository
{
    public interface ICuestionarioRepository
    {
        public Task SaveCuestionario(Cuestionario cuestionario);
        public Task<List<Cuestionario>> GetListCuestionarios();
        public Task<List<Cuestionario>> GetCuestionariosByUser(int idUsuario);
        public Task<Cuestionario> GetCuestionario(int? idByusuario);
        public Task DeleteCuestionario(Cuestionario cuestionario);
    }
}
