using System;
using System.Collections.Generic;

namespace SoftwareAPI.DTOs.Game
{
    public class PostGameDTO
    {
        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public IEnumerable<Guid> GenresId { get; set; }
    }
}
