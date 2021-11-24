using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Data
{
    public class JobApplication
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Applicant))]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
        public DateTime DateOfAplication { get; set; }
    }
}
