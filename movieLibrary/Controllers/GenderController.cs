using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieLibrary.DTO;
using movieLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace movieLibrary.Controllers
{
    [ApiController]
    [Route("api/genders")]
    public class GenderController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public GenderController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Insert one gender
        [HttpPost("insertone")]
        public async Task<ActionResult> Post(GenderCreateDto genderCreateDto)
        {
            var gender = mapper.Map<Gender>(genderCreateDto);

            context.Add(gender);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Insert serveral genders
        [HttpPost("insertserveral")]
        public async Task<ActionResult> Post(GenderCreateDto[] genderCreateDto)
        {
            var genders = mapper.Map<Gender[]>(genderCreateDto);
            context.AddRange(genders);
            await context.SaveChangesAsync();
            return Ok();
        }
        
        //Get all genders 
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Gender>>> Get() 
        {
            return await context.Genders.ToListAsync();
        }

        //Get gender by id
         [HttpGet("getone/{id:int}")]
        public async Task<ActionResult<Gender>> Get(int id) 
        {        
            var gender = await context.Genders.FindAsync(id);

            if(gender is null)
            {
                return NotFound();
            }
            return gender;
        }

        //Delete gender by id
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteGender = await context.Genders.Where(g => g.Idgender == id).ExecuteDeleteAsync();

            if (deleteGender == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
