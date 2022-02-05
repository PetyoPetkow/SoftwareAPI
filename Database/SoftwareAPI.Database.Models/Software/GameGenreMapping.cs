using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareAPI.Database.Models.Software
{
    public class GameGenreMapping : BaseModel
    {
        public GameGenreMapping()
            :base()
        {

        }

        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }

        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
