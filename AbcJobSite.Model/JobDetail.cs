using AbcJobSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class JobDetail
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }

        public string JobDescription { get; set; }
   
        public string Location { get; set; }
        public JobType TypeOfJob{ get; set; }
        public List<EmployerDetail> Employers { get; set; }

    }
}
