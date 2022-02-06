namespace SoftwareAPI.DTOs.Type
{
    using System;

    public class GetTypeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
