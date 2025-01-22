using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class Department : BaseEntity
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
    }
}
