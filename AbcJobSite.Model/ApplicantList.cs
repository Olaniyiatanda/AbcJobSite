using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class ApplicantList
    {
        public int Id { get; set; }
        [Display(Name = "First & Last Name")]
        public string ApplicantName { get; set; }
        [Display(Name = "Email Address")]
        public string ApplicantEmail { get; set; }
       
    }
}
