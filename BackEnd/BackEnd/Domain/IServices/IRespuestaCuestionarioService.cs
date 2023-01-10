using BackEnd.Domain.Model;

namespace BackEnd.Domain.IServices
{
    public interface IRespuestaCuestionarioService
    {
        Task SaveRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
        Task<List<RespuestaCuestionario>> ListCuestionarios(int idCuestionario, int idUsuario);
        Task<RespuestaCuestionario> Cuestionario(int idCuestionario, int idUsuario);
        Task DeleteCuestionario(int idCuestionario, int idUsuario);

    }
}
