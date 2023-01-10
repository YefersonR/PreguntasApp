using BackEnd.Domain.Model;

namespace BackEnd.Domain.IServices
{
    public interface ICuestionarioService
    {
        public Task SaveCuestionario(Cuestionario cuestionario);
        public Task<List<Cuestionario>> GetListCuestionarios();
        public Task<List<Cuestionario>> GetCuestionariosByUser(int idUsuario);
        public Task<Cuestionario> GetCuestionario(int? idCuestionario);
        public Task DeleteCuestionario(Cuestionario cuestionario);

    }
}
