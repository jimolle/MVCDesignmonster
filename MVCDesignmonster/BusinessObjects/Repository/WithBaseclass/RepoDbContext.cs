using System.Data.Entity;
using System.Web.WebPages;

namespace MVCDesignmonster.BusinessObjects.Repository.WithBaseclass
{ 
    public class RepoDbContext : DbContext, IDisposedTracker
    {
        public RepoDbContext()
            : base("ProfileDb")
        {
        }

        public static RepoDbContext Create()
        {
            return new RepoDbContext();
        }
        
        public bool IsDisposed { get; set; }
        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }


        public DbSet<StartPage> StartPage { get; set; }
    }
}
