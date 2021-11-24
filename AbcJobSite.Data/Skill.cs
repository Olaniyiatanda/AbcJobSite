using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Data
{
    public class Skill
    {
        public int Id{ get; set; }
        public string SkillName { get; set; }
        [ForeignKey (nameof(Applicant))]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant{ get; set; }
       

    }
}
