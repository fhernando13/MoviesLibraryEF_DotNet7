using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieLibrary.DTO;
using movieLibrary.Entities;
using Microsoft.AspNetCore.Authorization;

namespace movieLibrary.Controllers
{
    [ApiController]
    [Route("api/movies/{movieid:int}/comment")]
    [Authorize]
    public class CommentController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public CommentController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Insert one comment
        [HttpPost("insertcomment")]
        public async Task<ActionResult> Post(int movieid, CommentCreateDto commentCreateDto)
        {
            var comment = mapper.Map<Comment>(commentCreateDto);
            comment.Movieid = movieid;
            context.Add(comment);
            await context.SaveChangesAsync();
            return Ok();
        }

        //Get all comments 
        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Comment>>> Get() 
        {
            return await context.Comments.ToListAsync();
        }

        //Get comment by id
         [HttpGet("getone/{id:int}")]
        public async Task<ActionResult<Comment>> Get(int id) 
        {        
            var comment = await context.Comments.FindAsync(id);

            if(comment is null)
            {
                return NotFound();
            }
            return comment;
        }

        //Delete comment by id
        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteComment = await context.Comments.Where(g => g.Idcomment == id).ExecuteDeleteAsync();

            if (deleteComment == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        //Update actor
        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> Put(int id, CommentCreateDto commentCreateDto)
        {
            var comment = mapper.Map<Comment>(commentCreateDto);
            comment.Idcomment = id;
            context.Update(comment);
            await context.SaveChangesAsync();
            return Ok();
        }
        
    }
}