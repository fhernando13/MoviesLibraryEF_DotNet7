using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieLibrary.DTO;
using movieLibrary.Helpers;
using movieLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace movieLibrary.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    
    public class UserController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public UserController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Check email existing
        private Task<bool> CheckEmailExistAsync(string? Email)
            => context.Users.AnyAsync(x => x.Email == Email);


        //Insert one user
        [HttpPost("register")]
        public async Task<ActionResult> Post(User userCreateDto)
        {
            var user = mapper.Map<User>(userCreateDto);   
            // check email
            if (await CheckEmailExistAsync(user.Email))
                return BadRequest(new { Message = "Email Already Exist" });                

            user.Password = EncryptPassword.HashPassword(user.Password);
            context.Add(user);
            await context.SaveChangesAsync();
            return Ok(new
            {
                Message = "User registred"
            });
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