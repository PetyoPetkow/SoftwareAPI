namespace SoftwareAPI.Database.Models.Software
{
    using SoftwareAPI.Database.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    public class Genre : BaseModel, IDeletable
    {
        public Genre()
            : base()
        {
            this.Games = new HashSet<GameGenreMapping>();
        }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<GameGenreMapping> Games { get; set; }
    }
}
