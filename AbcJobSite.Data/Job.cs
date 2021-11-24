using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Data
{
    public enum JobType
    {
        Remote=1,
        Onsite
    }
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public  JobType TypeOfJob { get; set; }
        [ForeignKey(nameof(Employer))]
        public int EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; }

    }

   
}
