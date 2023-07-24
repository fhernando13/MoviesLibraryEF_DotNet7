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
        
        [HttpPost("insertone")]
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

        //Get all movies 
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Movie>>> Get() 
        {
            return await context.Movies.ToListAsync();
        }

        //Get movie by name
        [HttpGet("getbytitle")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetV2(string title) 
        {        
            return await context.Movies.Where(n => n.Title.Contains(title)).ToListAsync();
        }
        
        //Get movie by id
         [HttpGet("getone/{id:int}")]
        public async Task<ActionResult<Movie>> Get(int id) 
        {        
            var movie = await context.Movies.FindAsync(id);

            if(movie is null)
            {
                return NotFound();
            }
            return movie;
        }

        //Delete gender by id
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteMovie = await context.Movies.Where(g => g.Idmovie == id).ExecuteDeleteAsync();

            if (deleteMovie == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        //Update actor
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> Put(int id, MovieCreateDto movieCreateDto)
        {
            var movie = mapper.Map<Movie>(movieCreateDto);
            movie.Idmovie = id;
            context.Update(movie);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}