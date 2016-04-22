using System;
using System.ComponentModel.DataAnnotations;

namespace MVCDesignmonster.BusinessObjects.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Måste vara mellan 5 och 100 tecken!")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public bool Public { get; set; }
    }
}