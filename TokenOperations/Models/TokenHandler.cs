using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.IdentityModel.Tokens;
using PatikaAkbankBookstore.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



namespace PatikaAkbankBookstore.TokenOperations.Models
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            tokenModel.ExpirationDate = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken
            {
                Issuer = Configuration["Token:Issuer"],
                Audience = Configuration["Token:Audience"],
                Expires = tokenModel.ExpirationDate,
                NotBefore = DateTime.Now,
                SigningCredentials = credentials
            };


            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            tokenModel.RefreshToken = CreateRefreshToken();
            return tokenModel;
        }
    public string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}
}




