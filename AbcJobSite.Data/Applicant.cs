using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Data
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ApplicantName { get; set; }
        [Required]
        public string ApplicantEmail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime? CreatedUtc { get; set; }
        public string Skill { get; set; }

        //public virtual List <Skill> Skills { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; }
    }
}
