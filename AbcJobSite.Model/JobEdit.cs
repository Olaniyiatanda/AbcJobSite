using AbcJobSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class JobEdit
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public String JobDescription { get; set; }
        public string Location { get; set; }
        public JobType TypeOfJob { get; set; }

    }
}
