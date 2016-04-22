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
        [MinWords(5, ErrorMessage = "Minst 5 ord")]
        [MaxWords(25, ErrorMessage = "Max 25 ord")]
        public string WelcomeTitle { get; set; }
        [MinWords(100, ErrorMessage = "Minst 100 ord")]
        [MaxWords(150, ErrorMessage = "Max 150 ord")]
        public string WelcomeText { get; set; }
    }

    public class Profile
    {
        //public int ProfileId { get; set; }
        public int ProfileId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PublicPresentationText { get; set; }
        public bool ShowProfileForAnonymous { get; set; }
        public string PrivatePresentationText { get; set; }

        // TODO Nån form av bild alt. bilder!?
    }

    public class Education
    {
        public int EducationId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public string SchoolName { get; set; }
        public string Description { get; set; }
        public bool Public { get; set; }
    }

    public class Employer
    {
        public int EmployerId { get; set; }
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
