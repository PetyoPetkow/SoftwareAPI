using SoftwareAPI.Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAPI.Database.Models.Software
{
    public class Type : BaseModel, IDeletable
    {
        public Type()
            :base()
        {

        }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Utility> Utilities { get; set; }
    }
}
