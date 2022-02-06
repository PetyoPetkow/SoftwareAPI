namespace SoftwareAPI.Infrastructure.AutoMapperProfiles
{
    using AutoMapper;
    using SoftwareAPI.Database.Models.Software;
    using SoftwareAPI.DTOs.Game;
    using System.Collections.Generic;
    using System.Linq;

    public class GameProfile : Profile
    {
        public GameProfile()
        {
            this.CreateMap<Game, GetGameDTO>()
                .ForMember(ggdto => ggdto.Publisher, g => g.MapFrom(game => game.Publisher));

            this.CreateMap<IEnumerable<Game>, GetAllGamesDTO>()
                .ForMember(ggdto => ggdto.Games, g => g.MapFrom(games => games))
                .ForMember(ggdto => ggdto.GamesCount, g => g.MapFrom(games => games.Count()));

            this.CreateMap<PostGameDTO, Game>();
            this.CreateMap<PutGameDTO, Game>();
        }
    }
}
