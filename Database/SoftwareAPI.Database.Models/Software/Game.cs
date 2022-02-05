namespace SoftwareAPI.Database.Models.Software
{
    using SoftwareAPI.Database.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Game : BaseModel, IDeletable
    {
        public Game()
            :base()
        {
            this.Genres = new HashSet<GameGenreMapping>();
        }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<GameGenreMapping> Genres { get; set; }
    }
}
