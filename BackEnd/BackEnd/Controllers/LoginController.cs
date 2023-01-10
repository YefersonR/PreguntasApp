using BackEnd.Domain.IServices;
using BackEnd.Domain.Model;
using BackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginService service, IConfiguration configuration)
        {
            _service= service;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Usuario  usuario)
        {
            try
            {
                usuario.Password = Encripted.EncriptedPassword(usuario.Password);
                var User = await _service.Login(usuario);
                if(User == null)
                {
                    return BadRequest(new {message="usuario o contrasena invalido"});
                }
                var Token = JWTokenConfiguration.Gettoken(User,_configuration);
                return Ok(new {token = Token});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
