using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCDesignmonster.BusinessObjects.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ProfileDbContext")
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}