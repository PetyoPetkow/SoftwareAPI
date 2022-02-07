using SoftwareAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftwareAPI.DTOs.Genre
{
    public class PutGenreDTO
    {
        [Required]
        [MaxLength(ModelConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }
    }
}
