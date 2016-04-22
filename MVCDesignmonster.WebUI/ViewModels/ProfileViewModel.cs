using System.Collections.Generic;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.WebUI.ViewModels
{
    public class ProfileViewModel
    {
        public Profile Profile { get; set; }
        public IEnumerable<Education>Educations { get; set; }
        public IEnumerable<Employer> Employers { get; set; }
    }
}