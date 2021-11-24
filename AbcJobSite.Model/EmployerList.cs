using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcJobSite.Model
{
    public class EmployerList
    {
        public int Id { get; set; }
        [Display(Name = "Organization Name")]
        public string EmployerName { get; set; }
        [Display(Name = "Organization Email")]
        public string EmployerEmail { get; set; }
    }
}
