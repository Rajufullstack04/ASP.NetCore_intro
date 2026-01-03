using ASP.NetCore_intro.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP.NetCore_intro.Services1
{


  
    public class JWTAuthenticationService : IJWTAuthentication
    {
        // issuer , audience , secret key
        private readonly string _issuer = "IndianRailways";
        private readonly string _audience = "RailwayPassengers";
        private readonly string _secret = "RailwayApp_JWT_Secret_Key_2025@Secure";

       
        // GENERATE JWT TOKEN


        public string GenareteJWTToken(string Username, string Password)
        {
            // throw new NotImplementedException();
            // claims (user details)
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.Role, "Passenger"),
                new Claim(ClaimTypes.Email, "raju.passenger@gmail.com"),
                new Claim(ClaimTypes.MobilePhone, "987-654-3210"),
                new Claim("PNR", "4567891230")
            };

            // secret key (bytes)
            var secretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_secret)
            );

            // signing credentials
            var signingCredentials =
                new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // create JWT token
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            // object to string convert -----serialize
            // string to object convert-------deserialize
            // serialize token
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

       
        // VALIDATE JWT TOKEN
      // we are validating the token from this functionality
        public bool ValidateJWTToken(string usertoken)
        {
            string token = usertoken;

            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,



                // to enssure my climis also need to be validated

                NameClaimType = ClaimTypes.Name,
                RoleClaimType = ClaimTypes.Role,



            };

            SecurityToken validatedToken;
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var token1 = token.Substring("Bearer ".Length).Trim();

            // throw new NotImplementedException();
          ClaimsPrincipal claimsPrincipal =  jwtTokenHandler.ValidateToken(token1, parameters, out validatedToken);

            return claimsPrincipal.Identity.IsAuthenticated;

            //if (claimsPrincipal != null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
         }
    }
}















