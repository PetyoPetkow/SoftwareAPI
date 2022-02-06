namespace SoftwareAPI.DTOs.Genre
{
    using System.Collections.Generic;

    public class GetAllGenresDTO
    {
        public IEnumerable<GetGenreDTO> Genres { get; set; }

        public int GenresCount { get; set; }
    }
}
