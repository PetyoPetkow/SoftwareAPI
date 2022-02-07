namespace SoftwareAPI.Database.Models.Software
{
    using SoftwareAPI.Common;
    using SoftwareAPI.Database.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Genre : BaseModel, IDeletable
    {
        public Genre()
            : base()
        {
            this.Games = new HashSet<GameGenreMapping>();
        }

        [Required]
        [MaxLength(ModelConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<GameGenreMapping> Games { get; set; }
    }
}
