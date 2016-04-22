using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDesignmonster.WordCount;

namespace MVCDesignmonster.Models
{
    public class Startpage
    {
        public int StartpageId { get; set; }
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Måste vara mellan 5 och 25 tecken!")]
        public string WelcomeTitle { get; set; }
        [MinWords(100, ErrorMessage = "Minst 100 ord")]
        [MaxWords(150, ErrorMessage = "Max 150 ord")]
        public string WelcomeText { get; set; }
    }

    public class Profile
    {
        public int ProfileId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Måste vara mellan 1 och 50 tecken!")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool ShowProfileForAnonymous { get; set; }
        [MinWords(50, ErrorMessage = "Minst 50 ord")]
        [MaxWords(200, ErrorMessage = "Max 200 ord")]
        public string PublicPresentationText { get; set; }
        [MinWords(100, ErrorMessage = "Minst 100 ord")]
        [MaxWords(1000, ErrorMessage = "Max 1000 ord")]
        public string PrivatePresentationText { get; set; }

        public string ImagePath { get; set; }
        // TODO Nån form av bild alt. bilder!?
    }

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

    public class StatLog
    {
        public int StatLogId { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
