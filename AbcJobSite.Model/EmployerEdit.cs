using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class EmployerEdit
    {
        public int Id { get; set; }
        [Display(Name = "Organization Name")]
        public string EmployerName { get; set; }
        [Display(Name = "Organization Email")]
        public string EmployerEmail { get; set; }
        [Display(Name = "Organization Address")]
        public string EmployerAddress { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
    }
}
