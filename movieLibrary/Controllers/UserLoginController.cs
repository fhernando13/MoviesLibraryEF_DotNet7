using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieLibrary.DTO;
using movieLibrary.Entities;
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
        public async Task<ActionResult> Post([FromBody] UserLoginCreateDto request)
        {
            var userAuthenticate = await context.Users.SingleOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);

            if(userAuthenticate != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));

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
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new{ token = ""});
            };
            }
            
        }
    }
