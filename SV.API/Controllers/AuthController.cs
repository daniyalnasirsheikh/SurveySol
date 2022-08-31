using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SV.API.jwtConfigurations;
using SV.Models.Common;

namespace SV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtBearerTokenSettings jwtTokenOptions;
        private readonly IWebHostEnvironment webHostEnvironment;
        //private readonly IAppUser appUserRepository;
        //private readonly IUserRefreshToken userRefreshToken;
        private readonly IConfiguration configuration;

        //public AuthController(IWebHostEnvironment WebHostEnvironment, IOptions<JwtBearerTokenSettings> jwtTokenOptions, IAppUser AppUserRepository, IUserRefreshToken UserRefreshToken, IConfiguration Configuration)
        public AuthController(IWebHostEnvironment WebHostEnvironment, IOptions<JwtBearerTokenSettings> jwtTokenOptions, IConfiguration Configuration)
        {
            this.jwtTokenOptions = jwtTokenOptions.Value;
            webHostEnvironment = WebHostEnvironment;
            //appUserRepository = AppUserRepository;
            //userRefreshToken = UserRefreshToken;
            configuration = Configuration;
        }
        [HttpGet]
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private string RemoveSpace(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                return Regex.Replace(str, " ", "");
            }

            return String.Empty;

        }
        [HttpGet]
        private List<Claim> GenerateUserClaims(AppUser identityUser)
        {
            List<Claim> UserClaimsList = new List<Claim>();

            if (identityUser != null)
            {
                foreach (var item in identityUser.AppUserRoles)
                {
                    UserClaimsList.Add(new Claim("Role", item?.Role));
                    foreach (var claim in item?.RolesClaimsList)
                    {

                        UserClaimsList.Add(new Claim(RemoveSpace(claim?.ClaimName), true.ToString()));

                    }
                    //UserClaimsList.Add(new Claim(ClaimTypes.Role, item.Name));
                    //UserClaimsList.AddRange(item.RoleClaims);

                }
                UserClaimsList.Add(new Claim(ClaimTypes.Name, identityUser?.Username ?? "Test"));
            }
            return UserClaimsList;
        }
        [HttpGet]
        private string GenerateToken(AppUser identityUser, out DateTime TokenExpriy)
        {

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(JwtBearerTokenSecretKey.Key);
                DateTime tokenExpiryDate = DateTime.UtcNow.AddMinutes(jwtTokenOptions.ExpiryTimeInMinute);

                var tokenDescriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(GenerateUserClaims(identityUser)),
                    Expires = tokenExpiryDate,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Audience = jwtTokenOptions.Audience,
                    Issuer = jwtTokenOptions.Issuer
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                TokenExpriy = tokenExpiryDate;

                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AppUser user)
        {
            try
            {
                List<IdentityError> error = new List<IdentityError>();

                //IdentityResult result = await appUserRepository.CheckOldPassword(user);


                //if (result != null && !result.Succeeded)
                //{
                //    error.Add(new IdentityError() { Code = "Short Password", Description = "You current password is too short. kindly update your password using forget password." });
                //    return new BadRequestObjectResult(error);

                //}

                //AppUser validuser = await appUserRepository.Login(user);
                //if (validuser == null)
                //{
                //    error.Add(new IdentityError() { Code = "Login Failed", Description = "Email Address or Password is Incorrect." });
                //    return new BadRequestObjectResult(error);
                //}
                //if (validuser != null && !(validuser.PhoneNumberConfirmed))
                //{
                //    error.Add(new IdentityError() { Code = "Phone Number Validation Failed", Description = "Phone number is not validated." });
                //    return new BadRequestObjectResult(error);
                //}
                //if (!String.IsNullOrEmpty(validuser.Profile?.Avatar))
                //{
                //    string path = Path.Combine(webHostEnvironment.WebRootPath, configuration["Images"], validuser.Profile?.Avatar);


                //    validuser.Profile.AvatarImg = ImageRepository.GetFiles(path, validuser.Profile?.Avatar);
                //}
                DateTime tokenexpiryDate;
                var token = GenerateToken(user, out tokenexpiryDate);
                var refreshToken = GenerateRefreshToken();
                UserRefreshToken refreshTokenObject = new UserRefreshToken() { RefreshToken = refreshToken, Token = token, RefreshTokenExpirey = DateTime.UtcNow.AddMinutes(jwtTokenOptions.RefreshTokenExpiryTimeInMinute), TokenRenewDate = DateTime.Now, UserId = user.Username };
                //userRefreshToken.Add(refreshTokenObject);
                refreshTokenObject.TokenExpiryDate = tokenexpiryDate;
                refreshTokenObject.User = user;
                return Ok(refreshTokenObject);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          

        }


        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(UserRefreshToken model)
        {

            if (model.RefreshToken != null && Convert.ToDateTime(model.RefreshTokenExpirey) > Convert.ToDateTime(DateTime.UtcNow))
            {
                var isValid = true; // await userRefreshToken.IsValid(model);
                //var tokencount = await userRefreshToken.Count(model.UserId);

                if (isValid)
                {
                    AppUser validuser = new AppUser { Username = "admin", Password = "123", ID = 1 }; // await appUserRepository.GetByUserId(model.UserId);
                    DateTime tokenexpiryDate;
                    var token = GenerateToken(validuser, out tokenexpiryDate);
                    var refreshToken = GenerateRefreshToken();
                    UserRefreshToken refreshTokenObject = new UserRefreshToken() { RefreshToken = refreshToken, Token = token, RefreshTokenExpirey = DateTime.UtcNow.AddMinutes(jwtTokenOptions.RefreshTokenExpiryTimeInMinute), TokenRenewDate = DateTime.Now, UserId = validuser.Username };

                    //if (tokencount > 1)
                    //{
                    //    userRefreshToken.Delete(model.UserId);
                    //    userRefreshToken.Add(refreshTokenObject);
                    //}
                    //else
                    //{


                    //    userRefreshToken.Update(refreshTokenObject.Id, refreshTokenObject);

                    //}

                    return Ok(refreshTokenObject);
                }
                else
                {
                    return BadRequest("Token is Not Vlaid");

                }


            }

            return BadRequest("Token Expired");

        }

        [HttpDelete]
        [Route("RefreshToken")]
        public IActionResult Logout(string Id)
        {
            try
            {
                //userRefreshToken.Delete(Id);
                return Ok(true);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpGet]
        [Route("GetPrincipalFromExpiredToken/{token}")]
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSection = configuration.GetSection("JwtBearerTokenSettings");
            var jwtBearerTokenSettings = jwtSection.Get<JwtBearerTokenSettings>();
            //var tokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
            //    ValidateIssuer = false,
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the server key used to sign the JWT token is here, use more than 16 chars")),
            //    ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            //};




            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = jwtBearerTokenSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtBearerTokenSettings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtBearerTokenSecretKey.Key)),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            Debug.WriteLine(principal);
            return principal;
        }

    }
}
