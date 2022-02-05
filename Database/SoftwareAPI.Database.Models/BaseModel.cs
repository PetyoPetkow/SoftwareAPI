namespace SoftwareAPI.Database.Models
{
    using System;

    public abstract class BaseModel
    {
        protected BaseModel()
        {
            this.id = Guid.NewGuid();
            this.CreatedOn = DateTime.UtcNow;
            this.UpdatedOn = null;

        }

        public Guid id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
