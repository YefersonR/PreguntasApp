using BackEnd.Domain.IServices;
using BackEnd.Domain.Model;
using BackEnd.DTO;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                var exist =  await _service.ValidateExistence(usuario);
                if (exist)
                {
                    return BadRequest(new {message = $"El usuario {usuario.NombreUsuario} ya existe"});
                }

                usuario.Password = Encripted.EncriptedPassword(usuario.Password);
                await _service.Register(usuario);
                return Ok( new {message = "El Usuario se registro correctamente"});
            }
            catch (Exception ex)    
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("changepassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePassword changePassword)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JWTokenConfiguration.GetTokenIdUsuario(identity);
                    var encriptedPassword = Encripted.EncriptedPassword(changePassword.ActualPassword);
                Usuario usuario = await _service.ValidatePassword(id,encriptedPassword);
                if(usuario == null)
                {
                    return BadRequest(new {message="La contrasena es incorrecta"});
                }

                usuario.Password = Encripted.EncriptedPassword(changePassword.NewPassword);
                await _service.ChangePassword(usuario);

                return Ok(new {message="La contrasena fue actualizada con exito"});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
