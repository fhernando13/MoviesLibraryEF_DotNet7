using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieLibrary.DTO;
using movieLibrary.Entities;

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

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreateDto actorCreateDto)
        {
            var actor = mapper.Map<Actor>(actorCreateDto);

            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("several")]
        public async Task<ActionResult> Post(ActorCreateDto[] actorCreateDto)
        {
            var actors = mapper.Map<Actor[]>(actorCreateDto);
            context.AddRange(actors);
            await context.SaveChangesAsync();
            return Ok();
        }

        
    }
}