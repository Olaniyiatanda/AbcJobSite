using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class SkillDetail
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public List<ApplicantDetail> Applicants { get; set; }
    }
}
