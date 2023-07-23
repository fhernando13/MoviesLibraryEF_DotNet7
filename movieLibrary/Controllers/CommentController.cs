using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieLibrary.DTO;
using movieLibrary.Entities;

namespace movieLibrary.Controllers
{
    [ApiController]
    [Route("api/movies/{movieid:int}/comment")]
    public class CommentController: ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public CommentController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int movieid, CommentCreateDto commentCreateDto)
        {
            var comment = mapper.Map<Comment>(commentCreateDto);
            comment.Movieid = movieid;
            context.Add(comment);
            await context.SaveChangesAsync();
            return Ok();
        }
        
    }
}