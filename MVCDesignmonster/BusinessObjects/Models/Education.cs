using System;
using System.ComponentModel.DataAnnotations;
using MVCDesignmonster.Service.WordCount;

namespace MVCDesignmonster.BusinessObjects.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Måste vara mellan 5 och 100 tecken!")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Måste vara mellan 5 och 100 tecken!")]
        public string SchoolName { get; set; }
        [MinWords(40, ErrorMessage = "Minst 40 ord")]
        [MaxWords(200, ErrorMessage = "Max 200 ord")]
        public string Description { get; set; }
        public bool Public { get; set; }
    }
}