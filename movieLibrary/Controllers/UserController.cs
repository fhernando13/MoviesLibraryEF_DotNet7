using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieLibrary.DTO;
using movieLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace movieLibrary.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public UserController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public static string EncrypPass(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        //Insert one user
        [HttpPost("insertone")]
        public async Task<ActionResult> Post(User userCreateDto)
        {
            var user = new User()
            {
                Iduser = userCreateDto.Iduser,
                Name = userCreateDto.Name,
                Lastname = userCreateDto.Lastname,
                Birthdate = userCreateDto.Birthdate,
                Role = userCreateDto.Role,
                Email = userCreateDto.Email,
                Password = EncrypPass(userCreateDto.Password)
            };            
            context.Add(user);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Get all users
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<User>>> Get() 
        {
            return await context.Users.ToListAsync();
        }

        //Get user by id
        [HttpGet("getone/{id:int}")]
        public async Task<ActionResult<User>> Get(int id) 
        {        
            var user = await context.Users.FindAsync(id);

            if(user is null)
            {
                return NotFound();
            }
            return user;
        }

        //Delete user by id
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteUser = await context.Users.Where(g => g.Iduser == id).ExecuteDeleteAsync();

            if (deleteUser == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        //Update user
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> Put(int id, UserCreateDto userCreateDto)
        {
            var user = mapper.Map<User>(userCreateDto);
            user.Iduser = id;
            context.Update(user);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}