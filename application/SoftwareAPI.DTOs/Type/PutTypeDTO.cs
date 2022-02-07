using SoftwareAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftwareAPI.DTOs.Type
{
    public class PutTypeDTO
    {
        [MaxLength(ModelConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }
    }
}
