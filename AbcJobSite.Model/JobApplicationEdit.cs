using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class JobApplicationEdit
    {
        public int Id { get; set; }
        public int ApplicantId
        {
            get; set;
        }
        public int JobId
        {
            get; set;
        }
        public DateTime DateTimeNow
        {
            get; set;
        }
    }
}
