using BackEnd.Domain.IRepository;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Model;

namespace BackEnd.Services
{
    public class CuestionarioService : ICuestionarioService
    {
        private readonly ICuestionarioRepository _cuestionarioRepository;
        public CuestionarioService(ICuestionarioRepository cuestionarioRepository)
        {
            _cuestionarioRepository = cuestionarioRepository;
        }

        public async Task DeleteCuestionario(Cuestionario cuestionario)
        {
            await _cuestionarioRepository.DeleteCuestionario(cuestionario);
        }

        public async Task<Cuestionario> GetCuestionario(int? idCuestionario = 0)
        {
            return await _cuestionarioRepository.GetCuestionario(idCuestionario);
        }

        public async Task<List<Cuestionario>> GetCuestionariosByUser(int idUsuario)
        {
            return await _cuestionarioRepository.GetCuestionariosByUser(idUsuario);
        }

        public async Task<List<Cuestionario>> GetListCuestionarios()
        {
            return await _cuestionarioRepository.GetListCuestionarios();
        }

        public async Task SaveCuestionario(Cuestionario cuestionario)
        {
            await _cuestionarioRepository.SaveCuestionario(cuestionario);
        }
    }
}
