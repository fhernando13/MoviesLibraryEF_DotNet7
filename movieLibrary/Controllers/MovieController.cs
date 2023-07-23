using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieLibrary.DTO;
using movieLibrary.Entities;

namespace movieLibrary.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public MovieController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        [HttpPost]
        public async Task<ActionResult> Post(MovieCreateDto movieCreateDto)
        {
            var movie = mapper.Map<Movie>(movieCreateDto);

            if (movie.Genders is not null)
            {
                foreach (var gender in movie.Genders)
                {
                    context.Entry(gender).State = EntityState.Unchanged;
                }
            }

            if (movie.MovieActors is not null)
            {
                for (int i = 0; i < movie.MovieActors.Count; i++)
                {
                    movie.MovieActors[i].Order = i +1;
                }
            }
            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok();
           
        }

    }
}