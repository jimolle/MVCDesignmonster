using System.ComponentModel.DataAnnotations;
using MVCDesignmonster.Service.WordCount;

namespace MVCDesignmonster.BusinessObjects.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Måste vara mellan 1 och 50 tecken!")]
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Ange en giltig epostadress.")]
        //Redundant att kolla regexp, DataType.EmailAdress verkar kolla i princip samma sak...
        //[RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Ange en giltig epostadress.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Visa profil för ej påloggade?")]
        public bool ShowProfileForAnonymous { get; set; }
        [MinWords(50, ErrorMessage = "Minst 50 ord")]
        [MaxWords(200, ErrorMessage = "Max 200 ord")]
        [Display(Name = "Publik presentationstext")]
        [DataType(DataType.MultilineText)]
        public string PublicPresentationText { get; set; }
        [MinWords(100, ErrorMessage = "Minst 100 ord")]
        [MaxWords(1000, ErrorMessage = "Max 1000 ord")]
        [Display(Name = "Privat presentationstext")]
        [DataType(DataType.MultilineText)]
        public string PrivatePresentationText { get; set; }

        public string ImagePath { get; set; }
    }
}