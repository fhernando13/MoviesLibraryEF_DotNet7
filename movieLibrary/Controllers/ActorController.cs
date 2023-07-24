using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieLibrary.DTO;
using movieLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace movieLibrary.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public ActorController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Insert one actor
        [HttpPost("insertone")]
        public async Task<ActionResult> Post(ActorCreateDto actorCreateDto)
        {
            var actor = mapper.Map<Actor>(actorCreateDto);

            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Insert serveral actors
        [HttpPost("insertseveral")]
        public async Task<ActionResult> Post(ActorCreateDto[] actorCreateDto)
        {
            var actors = mapper.Map<Actor[]>(actorCreateDto);
            context.AddRange(actors);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Get all actors
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get() 
        {
            return await context.Actors.ToListAsync();
        }

        //Get actor by name complete
        [HttpGet("namecomplete")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string name) 
        {        
            return await context.Actors.Where(n => n.Name == name).ToListAsync();
        }

        //Get actor by name
        [HttpGet("getbyname")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetV2(string name) 
        {        
            return await context.Actors.Where(n => n.Name.Contains(name)).ToListAsync();
        }

        //Get actor by id
        [HttpGet("getone/{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id) 
        {        
            var actor = await context.Actors.FindAsync(id);

            if(actor is null)
            {
                return NotFound();
            }
            return actor;
        }

        //Delete actor by id
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteActor = await context.Actors.Where(g => g.Idactor == id).ExecuteDeleteAsync();

            if (deleteActor == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        //Update actor
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> Put(int id, ActorCreateDto actorCreateDto)
        {
            var actor = mapper.Map<Actor>(actorCreateDto);
            actor.Idactor = id;
            context.Update(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
