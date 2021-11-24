using AbcJobSite.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class ApplicantCreate
    {
        [Display(Name = "Applicant First & Last Name")]
        public string ApplicantName { get; set; }
        [Display(Name = "Email Address")]
        public string ApplicantEmail { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Your preferred Location")]
        public string Location { get; set; }
        [Display(Name = "Physical Address")]

        public string Address { get; set; }
        [Display(Name = "Time Applied")]
        public DateTime? CreatedUtc { get; set; }
        [Display(Name = "List your Skills")]
        public string Skill { get; set; }


    }   
}
