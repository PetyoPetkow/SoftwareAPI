namespace SoftwareAPI.DTOs.Game
{
    using SoftwareAPI.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PostGameDTO
    {
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

        public IEnumerable<Guid> GenresId { get; set; }
    }
}
