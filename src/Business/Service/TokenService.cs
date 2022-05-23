using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AM.Amil.PeNaAreia.Domain.Dto;

namespace AM.Amil.PeNaAreia.Business.Service
{
    public static class TokenService
    {
        public static object GerarTokenJwt(LoginDto login, IConfiguration configuration)
        {
            //var claims = new List<Claim>
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub, login.Login),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    new Claim("id", login.Id.ToString())
            //};

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expires = DateTime.UtcNow.AddHours(Convert.ToDouble(configuration["JwtExpire"]));


            //var token = new JwtSecurityToken(
            //    configuration["JwtIssuer"],
            //    configuration["JwtIssuerIn"],
            //    claims,
            //    expires: expires,
            //    signingCredentials: creds
            //);

            //return new JwtSecurityTokenHandler().WriteToken(token);
            return "";
        }
    }
}
