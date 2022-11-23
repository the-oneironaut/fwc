using System.ComponentModel.DataAnnotations;

namespace FlatworldConnect.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        [Required(ErrorMessage = "Customer name is required")]
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public string customerLocation { get; set; }
        [Required(ErrorMessage = "Customer email address is required")]
        //[RegularExpression(@"/.+\@.+\..+/", ErrorMessage = "Invalid email address!")]
        public string customerEmail { get; set; }
        public long customerPhone { get; set; }
    }
}
