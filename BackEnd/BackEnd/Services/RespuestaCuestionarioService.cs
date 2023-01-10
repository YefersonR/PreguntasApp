using BackEnd.Domain.IRepository;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Model;

namespace BackEnd.Services
{
    public class RespuestaCuestionarioService: IRespuestaCuestionarioService
    {
        private readonly IRespuestaCuestionarioRepository _repository;
        public RespuestaCuestionarioService(IRespuestaCuestionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
            await _repository.SaveRespuestaCuestionario(respuestaCuestionario);
        }
        public async Task<List<RespuestaCuestionario>> ListCuestionarios(int idCuestionario, int idUsuario)
        {
            return await _repository.ListCuestionarios(idCuestionario, idUsuario);
        }

        public async Task<RespuestaCuestionario> Cuestionario(int idCuestionario, int idUsuario)
        {
            return await _repository.Cuestionario(idCuestionario,idUsuario);
        }
        public async Task DeleteCuestionario(int idCuestionario, int idUsuario)
        {
            var respuestaCuestionario = await _repository.Cuestionario(idCuestionario,idUsuario);
            await _repository.DeleteRespuestaCuestionario(respuestaCuestionario);
        }
    }
}
