using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Commands.PatientCommands;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppointmentSystem.Application.Tools
{
    public class JwtTokenProcesses
    {
        public static PatientUserListDTO GenerateToken(PatientUserListDTO dto)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Hasta"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.AppUserId.ToString()));
            if (!string.IsNullOrWhiteSpace(dto.IdentifierNumber))
                claims.Add(new Claim("IdentifierNumber", dto.IdentifierNumber));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signinCredentials);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            dto.Token = tokenHandler.WriteToken(token);
            dto.TokenExpireDate = expireDate;
            return dto;
        }

        public static DoctorUserLoginDTO GenerateToken(DoctorUserLoginDTO dto)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Hasta"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.AppUserId.ToString()));
            if (!string.IsNullOrWhiteSpace(dto.IdentifierNumber))
                claims.Add(new Claim("IdentifierNumber", dto.IdentifierNumber));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signinCredentials);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            dto.Token = tokenHandler.WriteToken(token);
            dto.TokenExpireDate = expireDate;
            return dto;
        }
    }
}
