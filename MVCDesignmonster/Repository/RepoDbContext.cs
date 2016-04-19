using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class RepoDbContext : IdentityDbContext<ApplicationUser>
    {
        public RepoDbContext()
            : base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UsersPersonalProfileDb.mdf;Initial Catalog=UsersPersonalProfileDb;Integrated Security=True")
        {
            Database.SetInitializer<RepoDbContext>(new PersonalProfileDbInitializer());
        }

        public DbSet<Startpage> Startpage { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employer> Employers { get; set; }
    }

    public class PersonalProfileDbInitializer : DropCreateDatabaseAlways<RepoDbContext>
    {
        protected override void Seed(RepoDbContext context)
        {
            var startpage = new Startpage()
            {
                WelcomeTitle = "Välkommen till den här sidan.",
                WelcomeText =
                    "[WelcomeText] Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. "
            };
            context.Startpage.Add(startpage);

            var profile = new Profile()
            {
                Name = "Förnamn Efternamn",
                Email = "test@test.com",
                PublicPresentationText = "[PublicPresentationText] Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. ",
                ShowPrivatePresentationText = true,
                PrivatePresentationText = "[PrivatePresentationText] Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. ",
            };
            context.Profile.Add(profile);

            var educations = new List<Education>
            {
                new Education()
                {
                    Name = "DirtShoweling101",
                    Description = "A good education about showeling dirt",
                    SchoolName = "FiveGardens",
                    StartDate = DateTime.Parse("2010-01-01 00:00:00"),
                    EndDate = DateTime.Parse("2011-01-01 00:00:00"),
                    Public = true
                },
                new Education()
                {
                    Name = "Databases101",
                    Description = "A good education about DbContext",
                    SchoolName = "SchoolOfDatabases",
                    StartDate = DateTime.Parse("2012-01-01 00:00:00"),
                    EndDate = DateTime.Parse("2013-01-01 00:00:00"),
                    Public = true
                }
            };
            foreach (var education in educations)
                context.Educations.Add(education);


            var employers = new List<Employer>
            {
                new Employer()
                {
                    Name = "Bofors AB",
                    StartDate = DateTime.Parse("2013-01-01 00:00:00"),
                    EndDate = DateTime.Parse("2013-06-01 00:00:00"),
                    Public = true
                },
                new Employer()
                {
                    Name = "Rädda Barnen Pakistan",
                    StartDate = DateTime.Parse("2014-06-01 00:00:00"),
                    EndDate = DateTime.Parse("2014-08-31 00:00:00"),
                    Public = true
                }
            };
            foreach (var employer in employers)
                context.Employers.Add(employer);



            // USERS AND ROLES
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Administrator", "User" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                if (!roleManager.RoleExists(roleName))
                {
                    roleResult = roleManager.Create(new IdentityRole(roleName));
                }
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@admin.com" };

                manager.Create(user, "samme1");
                manager.AddToRole(user.Id, "Administrator");
            }

            if (!(context.Users.Any(u => u.UserName == "user3@user3.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "user3@user3.com", Email = "user3@user3.com" };
                userManager.Create(userToInsert, "samme1");
                userManager.AddToRole(userToInsert.Id, "User");
            }

            context.SaveChanges();


            base.Seed(context);
        }
    }
}
