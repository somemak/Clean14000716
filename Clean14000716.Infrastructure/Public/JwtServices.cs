using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Common.ForAutofacMark;
using Clean14000716.Common.Utilities;
using Clean14000716.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Clean14000716.Infrastructure.Public
{
    public class JwtServices : IJwtServices, IScopedDependency
    {
        private readonly SiteSettings _siteSettings;
        public JwtServices(IOptionsSnapshot<SiteSettings> settings)
        {
            _siteSettings = settings.Value;
        }
        public string GenerateToken(User user)
        {

 
            //var encryptionKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.EncryptKey); //must be 16 char
            //var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionKey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var secretKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.SecretKey); // must be 16 char or high 
            var encryptionKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.EncryptKey);  
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionKey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            //var secretKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.SecretKey);  
 
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature);

            var claims = _getClaims(user);

            var descriptor = new SecurityTokenDescriptor()
            {
                Issuer = _siteSettings.JwtSettings.Issuer,
                Audience = _siteSettings.JwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.ExpirationMinutes),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims),
                EncryptingCredentials = encryptingCredentials
            };

            // if user 3 follow line not map .net clam name to jwt clam
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();



            var jwtHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtHandler.CreateToken(descriptor);

            var jwt = jwtHandler.WriteToken(securityToken);

            return jwt;
        }

        private IEnumerable<Claim> _getClaims(User user)
        {
            var claimsIdentityOptions = new ClaimsIdentityOptions().SecurityStampClaimType;
            var list = new List<Claim>()
            {
                //new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(claimsIdentityOptions,user.SecurityStamp.ToString())
            };

            //get role of user from database
            var roles = new Role[] { new Role() { Name = "Admin" }, new Role() { Name = "user" } };
            list.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            return list;
        }
    }
}