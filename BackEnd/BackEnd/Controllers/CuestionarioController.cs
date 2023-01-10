using BackEnd.Domain.IServices;
using BackEnd.Domain.Model;
using BackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuestionarioController : ControllerBase
    {
        private readonly ICuestionarioService _cuestionarioService;
        public CuestionarioController(ICuestionarioService cuestionarioService)
        {
            _cuestionarioService = cuestionarioService;
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] Cuestionario cuestionario)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JWTokenConfiguration.GetTokenIdUsuario(identity);

                cuestionario.UsuarioId = id;
                cuestionario.Activo = true;
                cuestionario.FechaCreacion = DateTime.Now;
                await _cuestionarioService.SaveCuestionario(cuestionario);
                return Ok(new { message = "Se agrego el cuestionario exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetListCuestionario")]
        [HttpGet]
        public async Task<IActionResult> GetListCuestionario()
        {
            try
            {
                List<Cuestionario> listCuestionario = await _cuestionarioService.GetListCuestionarios();
                if (listCuestionario is null || listCuestionario.Count == 0)
                {
                    return NotFound();
                }
                return Ok(listCuestionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{idCuestionario}")]
        public async Task<IActionResult> GetCuestionario(int idCuestionario)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JWTokenConfiguration.GetTokenIdUsuario(identity);


                Cuestionario cuestionario = await _cuestionarioService.GetCuestionario(idCuestionario);
                if (cuestionario is null)
                {
                    return NotFound();
                }
                return Ok(cuestionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetCuestionariosByUser")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetCuestionariosByUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JWTokenConfiguration.GetTokenIdUsuario(identity);

                List<Cuestionario> cuestionario = await _cuestionarioService.GetCuestionariosByUser(id);
                if (cuestionario is null || cuestionario.Count == 0)
                {
                    return NotFound();
                }
                return Ok(cuestionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{idCuestionario}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCuestionarios(int idCuestionario)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JWTokenConfiguration.GetTokenIdUsuario(identity);

                Cuestionario cuestionario = await _cuestionarioService.GetCuestionario(idCuestionario);
                if (cuestionario is null)
                {
                    return NotFound();
                }
                await _cuestionarioService.DeleteCuestionario(cuestionario);
                return Ok(new {message= "El mensaje fue eliminado con exito"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
