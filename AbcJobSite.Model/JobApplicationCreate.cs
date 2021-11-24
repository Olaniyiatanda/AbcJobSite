using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class JobApplicationCreate
    {
        public int ApplicantId { get; set; }
        
        public int JobId { get; set; }
        [Display(Name = "DateOfApplication")]
        public DateTime DateTimeNow { get; set; }
    }
}
