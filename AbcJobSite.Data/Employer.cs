using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Data
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployerEmail { get; set; }
        [Required]
        public string EmployerName { get; set; }
        [Required]
        public string EmployerAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public virtual List<Job> Jobs { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; }
    }
}
