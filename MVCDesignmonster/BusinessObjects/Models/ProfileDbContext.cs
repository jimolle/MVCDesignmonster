using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCDesignmonster.BusinessObjects.Models
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

    public class PersonalProfileDbInitializer : DropCreateDatabaseIfModelChanges<ProfileDbContext>
    //public class PersonalProfileDbInitializer : DropCreateDatabaseAlways<ProfileDbContext>
    {
        protected override void Seed(ProfileDbContext context)
        {
            var startpage = new Startpage()
            {
                WelcomeTitle = "Designmönster & MVC",
                WelcomeText =
                    "[WelcomeText] Välkommen, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor.  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor."
            };
            context.Startpage.Add(startpage);

            var profile = new Profile()
            {
                Name = "Samuel Pettersson",
                Email = "test@test.com",
                PublicPresentationText = "[PublicPresentationText] Detta är den publika presentationstexten, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. Some more words.",
                ShowProfileForAnonymous = true,
                PrivatePresentationText = "[PrivatePresentationText] Detta är den privata presentationstexten, den innehåller allt den publika innehöll, samt massor av andra godbitar. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. Some more words.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. Some more words. Some more words.",
            };
            context.Profile.Add(profile);

            var educations = new List<Education>
            {
                new Education()
                {
                    Name = "Utbildning",
                    Description = "A good education about educating.A good education about educating. A good education about educating. A good education about educating. A good education about educating. A good education about educating. A good education about educating. A good education about educating. A good education about educating. A good education about educating.",
                    SchoolName = "Statens läroverk",
                    StartDate = DateTime.Parse("2010-01-01"),
                    EndDate = DateTime.Parse("2011-01-01"),
                    Public = true
                },
                new Education()
                {
                    Name = "Databases101",
                    Description = "A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. A good education about DbContext. ",
                    SchoolName = "SchoolOfDatabases",
                    StartDate = DateTime.Parse("2012-01-01"),
                    EndDate = DateTime.Parse("2013-01-01"),
                    Public = false
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
                    Name = "MOL Shipping",
                    StartDate = DateTime.Parse("2014-06-01"),
                    EndDate = DateTime.Parse("2014-08-31"),
                    Public = false
                },
                new Employer()
                {
                    Name = "Parkförvaltningen",
                    StartDate = DateTime.Parse("2015-06-01"),
                    EndDate = null,
                    Public = false
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
