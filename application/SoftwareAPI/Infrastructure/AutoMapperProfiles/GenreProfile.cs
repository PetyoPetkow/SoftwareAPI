using AutoMapper;
using SoftwareAPI.Database.Models.Software;
using SoftwareAPI.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareAPI.Infrastructure.AutoMapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            this.CreateMap<Genre, GetGenreDTO>();
            this.CreateMap<IEnumerable<Genre>, GetAllGenresDTO>()
                .ForMember(gagdto =>gagdto.Genres, g=>g.MapFrom(genres=>genres))
                .ForMember(gagdto =>gagdto.GenresCount, g=>g.MapFrom(genres=>genres.Count()));
            this.CreateMap<Genre, PostGenreDTO>();
            this.CreateMap<Genre, PutGenreDTO>();
        }
    }
}
