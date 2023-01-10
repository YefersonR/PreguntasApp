using BackEnd.Domain.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.Utils
{
    public static class JWTokenConfiguration
    {
        public static string Gettoken(Usuario usuario, IConfiguration configuration)
        {
            var SecretKey = configuration["JWT:SecretKey"];
            var Issuer = configuration["JWT:Issuer"];
            var Audience = configuration["JWT:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,usuario.NombreUsuario),
                new Claim("IdUsuario",usuario.Id.ToString())
            };


            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience:Audience,
                Claims,
                expires:DateTime.Now.AddMinutes(90),
                signingCredentials:credentials
                );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static int GetTokenIdUsuario(ClaimsIdentity identity)
        {
            if(identity is not null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                foreach(Claim claim in claims)
                {
                    if(claim.Type == "IdUsuario")
                    {
                        return int.Parse(claim.Value);
                    }
                }
            }
            return 0;
        }
    }
}
