namespace SoftwareAPI.Database.Models.Software
{
    using SoftwareAPI.Common;
    using SoftwareAPI.Database.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Type : BaseModel, IDeletable
    {
        public Type()
            :base()
        {

        }

        [Required]
        [MaxLength(ModelConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Utility> Utilities { get; set; }
    }
}
