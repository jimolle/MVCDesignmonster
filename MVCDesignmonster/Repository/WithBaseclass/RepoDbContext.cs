using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace MVCDesignmonster.Repository.WithBaseclass
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
