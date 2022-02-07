namespace SoftwareAPI.DTOs.Utility
{
    using SoftwareAPI.Common;
    using System.ComponentModel.DataAnnotations;

    public class PostUtilityDTO
    {
        [MaxLength(ModelConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [MaxLength(ModelConstants.PUBLISHER_MAX_LENGTH)]
        public string Publisher { get; set; }

        [MaxLength(ModelConstants.DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        public int Price { get; set; }
    }
}
