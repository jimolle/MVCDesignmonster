using System.Collections.Generic;
using System.Linq;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;

namespace MVCDesignmonster.Test.Fakes
{
    public class FakeProfileRepository : IProfileRepository
    {
        private HashSet<Profile> _context = new HashSet<Profile>();

        public FakeProfileRepository()
        {
            var fakeProfile = new Profile()
            {
                ProfileId = 1,
                Name = "Test Testsson",
                Email = "test@test.com",
                ShowProfileForAnonymous = true,
                PublicPresentationText = "[Public Presentationtext]",
                PrivatePresentationText = "[Private Presentationtext]",
                ImagePath = "profilBild.jpg"
            };
            _context.Add(fakeProfile);
        }


        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Profile GetProfile()
        {
            return _context.FirstOrDefault();
        }

        public void UpdateProfile(Profile profile)
        {
            _context.First().Name = profile.Name;
            _context.First().ProfileId = profile.ProfileId;
            _context.First().Email = profile.Email;
            _context.First().ShowProfileForAnonymous = profile.ShowProfileForAnonymous;
            _context.First().PrivatePresentationText = profile.PrivatePresentationText;
            _context.First().PublicPresentationText = profile.PublicPresentationText;
            _context.First().ImagePath = profile.ImagePath;
        }

        public void Save()
        {
            //Do nothing
        }
    }
}