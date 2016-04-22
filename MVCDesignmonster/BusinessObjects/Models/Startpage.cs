using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCDesignmonster.Service.WordCount;

namespace MVCDesignmonster.BusinessObjects.Models
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
}
