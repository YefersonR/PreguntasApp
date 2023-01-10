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
    public class RespuestaCuestionarioController : ControllerBase
    {
        private readonly IRespuestaCuestionarioService _service;
        private readonly ICuestionarioService _serviceCuestionario;

        public RespuestaCuestionarioController(IRespuestaCuestionarioService service, ICuestionarioService serviceCuestionario)
        {
            _service = service;
            _serviceCuestionario = serviceCuestionario;
        }
        [HttpPost]
        public async Task<IActionResult> Post(RespuestaCuestionario respuestaCuestionario)
        {
            try
            {
                await _service.SaveRespuestaCuestionario(respuestaCuestionario);
                return Ok(respuestaCuestionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{idCuestionario}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListCuestionarios(int idCuestionario)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JWTokenConfiguration.GetTokenIdUsuario(identity);
                var listCuestionario = await _service.ListCuestionarios(idCuestionario, id);
                if (listCuestionario is null)
                {
                    return NotFound();
                }
                return Ok(listCuestionario);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Route("GetRespuestaCuestionarioById/{idRespuestaCuestionario}")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetRespuestaCuestionarioById(int idRespuestaCuestionario)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JWTokenConfiguration.GetTokenIdUsuario(identity);
                var respuestaCuestionario = await _service.Cuestionario(idRespuestaCuestionario, id);
                var idCuestionario = respuestaCuestionario.CuestionarioId!;
                var cuestionario = await _serviceCuestionario.GetCuestionario(idCuestionario);
                if (cuestionario is null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    cuestionario = cuestionario,
                    respuestas = respuestaCuestionario.RespuestaDetalles!
                                                      .Select(x => new RespuestaCuestionarioDetalle { RespuestaId = x.RespuestaId }).ToList()
                });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteRespuesta(int idCuestionario)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JWTokenConfiguration.GetTokenIdUsuario(identity);
                await _service.DeleteCuestionario(idCuestionario, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
