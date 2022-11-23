using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlatworldConnect.Models
{
    public class Project
    {
        [Key]
        public int projectId { get; set; }
        [Required]
        [Display(Name ="Project Name")]
        public string projectName { get; set; }
        [Required(ErrorMessage = "Please describe the project")]
        [Display(Name = "Description")]
        public string projectDesc { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [Display(Name = "Project Start Date")]
        public DateOnly projectStartDate { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [Display(Name = "Project End Date")]
        public DateOnly projectEndDate { get; set; }

        [Required]
        [ValidateNever]
        [Display(Name = "Customer")]
        public int customerId { get; set; }
        [ValidateNever]
        public Customer Customer { get; set; }

        [Required]
        [ValidateNever]
        [Display(Name = "Project Manager")]
        public int PMId { get; set; }
        [ValidateNever]
        public ProjectManager PM { get; set; }
    }

    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateOnly.ParseExact(reader.GetString()!, Format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }
    }
}
