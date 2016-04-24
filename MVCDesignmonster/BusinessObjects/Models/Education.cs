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
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Påbörjades")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Avslutades")]
        public DateTime? EndDate { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Måste vara mellan 5 och 100 tecken!")]
        [Display(Name = "Namn på skola")]
        public string SchoolName { get; set; }
        [MinWords(40, ErrorMessage = "Minst 40 ord")]
        [MaxWords(200, ErrorMessage = "Max 200 ord")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Display(Name = "Publik?")]
        public bool Public { get; set; }
    }
}