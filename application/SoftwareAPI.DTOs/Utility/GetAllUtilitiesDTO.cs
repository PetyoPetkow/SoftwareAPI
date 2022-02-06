namespace SoftwareAPI.DTOs.Utility
{
    using System.Collections.Generic;

    public class GetAllUtilitiesDTO
    {
        public int UtilitiesCount { get; set; }

        public ICollection<GetUtilityDTO> Utilities { get; set; }
    }
}
