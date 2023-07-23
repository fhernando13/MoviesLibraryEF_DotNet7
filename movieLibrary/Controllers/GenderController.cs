using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using movieLibrary.DTO;
using movieLibrary.Entities;

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

        [HttpPost]
        public async Task<ActionResult> Post(GenderCreateDto genderCreateDto)
        {
            var gender = mapper.Map<Gender>(genderCreateDto);

            context.Add(gender);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("several")]
        public async Task<ActionResult> Post(GenderCreateDto[] genderCreateDto)
        {
            var genders = mapper.Map<Gender[]>(genderCreateDto);
            context.AddRange(genders);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}