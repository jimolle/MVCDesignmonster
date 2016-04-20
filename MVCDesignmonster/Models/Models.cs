using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDesignmonster.Models
{
    public class Startpage
    {
        //public int ID { get; set; }
        public int StartpageId { get; set; }
        public string WelcomeTitle { get; set; }
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
        public bool ShowPrivatePresentationText { get; set; }
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
