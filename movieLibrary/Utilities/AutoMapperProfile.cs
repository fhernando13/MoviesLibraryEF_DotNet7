using AutoMapper;
using movieLibrary.DTO;
using movieLibrary.Entities;

namespace movieLibrary.Utilities
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenderCreateDto, Gender>();
            CreateMap<ActorCreateDto, Actor>();
            CreateMap<MovieCreateDto, Movie>()
                .ForMember(ent => ent.Genders, 
                dto => dto.MapFrom(field => field.Genders.Select(Idgender => new Gender {Idgender = Idgender})));
            CreateMap<MovieActorCreateDto, MovieActor>();
            CreateMap<CommentCreateDto, Comment>();

        }
    }
}