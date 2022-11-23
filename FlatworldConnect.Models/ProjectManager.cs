using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatworldConnect.Models
{
    public class ProjectManager
    {
        [Key]
        public int PMId { get; set; }
        [Required]
        public string PMName { get; set; }
        [Required]
        //[RegularExpression(@"/.+\@.+\..+/", ErrorMessage = "Invalid email address!")]
        public string PMEmail { get; set; }
        [Required]
        public string PMPassword { get; set; }
        [Required]
        //[RegularExpression(@"/^[6-9]{1}[0-9]{9}$/", ErrorMessage = "Enter Indian mobile number")]
        public long PMPhone { get; set; }
        public string PMLocation { get; set; }
        //[RegularExpression(@"/^[1-9]{1}\d{2}\s?\d{3}$/gm", ErrorMessage = "Enter valid zip code")]
        public int PMZipCode { get; set; }
        public string PMState { get; set; }
        public string PMAddress { get; set; }
    }
}
