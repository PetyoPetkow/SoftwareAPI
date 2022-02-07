namespace SoftwareAPI.Infrastructure.AutoMapperProfiles
{
    using AutoMapper;
    using SoftwareAPI.Database.Models.Software;
    using SoftwareAPI.DTOs.Genre;
    using System.Collections.Generic;

    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            this.CreateMap<Genre, GetGenreDTO>();
            this.CreateMap<PostGenreDTO, Genre>();
            this.CreateMap<ICollection<Genre>, GetAllGenresDTO>()
                .ForMember(ggdto => ggdto.Genres, g => g.MapFrom(genres => genres))
                .ForMember(ggdto => ggdto.GenresCount, g => g.MapFrom(genres => genres.Count));
            this.CreateMap<ICollection<GameGenreMapping>, GetAllGenresDTO>()
                .ForMember(ggdto => ggdto.Genres, g => g.MapFrom(genres => genres));
            this.CreateMap<GameGenreMapping, GetGenreDTO>()
                .ForMember(ggdto => ggdto.Id, bgm => bgm.MapFrom(mapping => mapping.GenreId))
                .ForMember(ggdto => ggdto.Name, bgm => bgm.MapFrom(mappin => mappin.Genre.Name));
            this.CreateMap<PutGenreDTO, Genre>();
        }
    }
}
