using System.ComponentModel.DataAnnotations;
using MVCDesignmonster.Service.WordCount;

namespace MVCDesignmonster.BusinessObjects.Models
{
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
}