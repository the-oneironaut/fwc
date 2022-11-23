using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatworldConnect.Models.ViewModels
{
    public class ProjectVM
    {
        public Project Project {get;set;}
        [ValidateNever]
        public IEnumerable<SelectListItem> CustomerList {get;set;}
        [ValidateNever]
        public IEnumerable<SelectListItem> ProjectManagerList { get; set; }
        [ValidateNever]
        public IEnumerable<Customer> Customers {get;set;}
        [ValidateNever]
        public IEnumerable<Project> Projects { get;set;}
        [ValidateNever]
        public IEnumerable<Resource> Resources {get;set;}
    }
}
