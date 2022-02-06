namespace SoftwareAPI.DTOs.Game
{
    using System.Collections.Generic;

    public class GetAllGamesDTO
    {
        public int GamesCount { get; set; }

        public ICollection<GetGameDTO> Games { get; set; }
    }
}
