namespace SoftwareAPI.Database.Models.Software
{
    using SoftwareAPI.Common;
    using SoftwareAPI.Database.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    

    public class Game : BaseModel, IDeletable
    {
        public Game()
            :base()
        {
            this.Genres = new HashSet<GameGenreMapping>();
        }

        [Required]
        [MaxLength(ModelConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ModelConstants.PUBLISHER_MAX_LENGTH)]
        public string Publisher { get; set; }

        [Required]
        [MaxLength(ModelConstants.DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<GameGenreMapping> Genres { get; set; }
    }
}
