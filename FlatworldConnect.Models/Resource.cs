using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlatworldConnect.Models
{
    public class Resource
    {
        [Key]
        public int resourceId { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public int projectId { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public int customerId { get; set; }
        [ValidateNever]
        public Customer customer { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string jobTitle { get; set; }

        [Required]
        [Display(Name = "Skill Set")]
        public string skillSet { get; set; }

        [Display(Name = "Experience")]
        public int experience { get; set; }

        [Display(Name = "Number of months")]
        public int noOfMonths { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [Display(Name = "Start Date")]
        public DateOnly startDate { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [Display(Name = "End Date")]
        public DateOnly endDate { get; set; }
        public int noOfResources { get; set; }


        
    }

    
}
