using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
        #nullable enable
        public IList<Task>? Tasks { get; set; }
        #nullable disable

    }
}
