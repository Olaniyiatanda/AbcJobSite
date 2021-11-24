using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class JobApplicationList
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        [Display(Name ="Applicant Name")]
        public string ApplicantName { get; set; }
        
        public string JobTitle { get; set; }
        public DateTime DateTimeNow { get; set; }
    }
}
