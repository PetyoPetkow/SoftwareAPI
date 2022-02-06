using SoftwareAPI.Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAPI.Database.Models.Software
{
    public class Utility : BaseModel, IDeletable
    {
        public Utility()
            :base()
        {

        }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public Guid TypeId { get; set; }
        public Type Type { get; set; }
    }
}
