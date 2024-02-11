using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieLibrary.DTO;
using movieLibrary.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;  
using System.Text;

namespace movieLibrary.Controllers
{
    [ApiController]
    [Route("api/autenthicate")]
    public class UserLoginController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly string secretKey;
        
        //Constructor
        public UserLoginController(AppDbContext context, IMapper mapper, IConfiguration config)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
            this.context = context;
            this.mapper = mapper;
        }
        
        //Login

        [HttpPost("login")]
        public async Task<ActionResult> Authenticate([FromBody] UserCreateDto request)
        {
            if (request == null)
                return BadRequest();

            var userAuthenticate = await context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if(userAuthenticate == null)
                return NotFound(new { Message = "User not found!" });

            if (!EncryptPassword.VerifyPassword(request.Password, userAuthenticate.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect" });
            }
            else
            {
                
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, userAuthenticate.Role),
                    new Claim(ClaimTypes.Name, $"{userAuthenticate.Nickname}")
                });
                

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreated = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new{ token = tokenCreated});
            }
            // else
            // {
            //     return StatusCode(StatusCodes.Status401Unauthorized, new{ token = ""});
            // };
        }            
    }
}
