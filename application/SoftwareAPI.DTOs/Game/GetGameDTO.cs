namespace SoftwareAPI.DTOs.Game
{
    using System;
    using System.Collections.Generic;

    using SoftwareAPI.Database.Models.Software;
    using SoftwareAPI.DTOs.Genre;

    public class GetGameDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public GetAllGenresDTO Genres { get; set; }

        public int GenresCount { get; set; }
    }
}
