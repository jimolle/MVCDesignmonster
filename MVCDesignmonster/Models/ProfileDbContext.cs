using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCDesignmonster.Models
{
    public class ProfileDbContext : ApplicationDbContext
    {
        public ProfileDbContext()
        {
            Database.SetInitializer<ProfileDbContext>(new PersonalProfileDbInitializer());
        }


        public DbSet<Startpage> Startpage { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<StatLog> StatLogs { get; set; }
    }

    public class PersonalProfileDbInitializer : DropCreateDatabaseAlways<ProfileDbContext>
    {
        protected override void Seed(ProfileDbContext context)
        {
            var startpage = new Startpage()
            {
                WelcomeTitle = "Titel för MVCDesignmonster aka ProfilSite v4.0",
                WelcomeText =
                    "[WelcomeText] Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor."
            };
            context.Startpage.Add(startpage);

            var profile = new Profile()
            {
                Name = "Förnamn Efternamn",
                Email = "test@test.com",
                PublicPresentationText = "[PublicPresentationText] Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. ",
                ShowProfileForAnonymous = true,
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
                    StartDate = DateTime.Parse("2010-01-01"),
                    EndDate = DateTime.Parse("2011-01-01"),
                    Public = true
                },
                new Education()
                {
                    Name = "Databases101",
                    Description = "A good education about DbContext",
                    SchoolName = "SchoolOfDatabases",
                    StartDate = DateTime.Parse("2012-01-01"),
                    EndDate = DateTime.Parse("2013-01-01"),
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
                    StartDate = DateTime.Parse("2013-01-01"),
                    EndDate = DateTime.Parse("2013-06-01"),
                    Public = true
                },
                new Employer()
                {
                    Name = "Rädda Barnen Pakistan",
                    StartDate = DateTime.Parse("2014-06-01"),
                    EndDate = DateTime.Parse("2014-08-31"),
                    Public = true
                }
            };
            foreach (var employer in employers)
                context.Employers.Add(employer);



            // USERS AND ROLES
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Admin", "Owner", "User" };
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
                var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com"};

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "owner@owner.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "owner@owner.com", Email = "owner@owner.co"};

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "Owner");
            }

            if (!(context.Users.Any(u => u.UserName == "user@user.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "user@user.com", Email = "user@user.com" };
                userManager.Create(userToInsert, "password");
                userManager.AddToRole(userToInsert.Id, "User");
            }

            context.SaveChanges();


            base.Seed(context);
        }
    }
}
