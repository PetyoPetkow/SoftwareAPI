using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAPI.DTOs.Type
{
    public class GetAllTypes
    {
        public int TypesCount { get; set; }

        public ICollection<Database.Models.Software.Type> Types { get; set; }
    }
}
