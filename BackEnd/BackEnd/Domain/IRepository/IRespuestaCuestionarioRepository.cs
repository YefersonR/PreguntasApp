using BackEnd.Domain.Model;

namespace BackEnd.Domain.IRepository
{
    public interface IRespuestaCuestionarioRepository
    {
        Task SaveRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
        Task<List<RespuestaCuestionario>> ListCuestionarios(int idCuestionario, int idUsuario);
        Task<RespuestaCuestionario> Cuestionario(int idRespuestaCuestionario, int idUsuario);
        Task DeleteRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);

    }
}
