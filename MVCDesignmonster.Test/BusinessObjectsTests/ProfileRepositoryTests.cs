using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;
using MVCDesignmonster.Test.Fakes;

namespace MVCDesignmonster.Test.BusinessObjectsTests
{
    [TestClass]
    public class ProfileRepositoryTests
    {
        private IProfileRepository _repo;

        public ProfileRepositoryTests()
        {
            _repo = new ProfileRepository(new ProfileDbContext());
            //_repo = new FakeProfileRepository();
        }


        [TestMethod]
        public void GetProfile()
        {
            // Arrange

            // Act
            Profile item = _repo.GetProfile();

            // Assert
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void UpdateProfile()
        {
            // Arrange
            var profile = _repo.GetProfile();

            // Act
            profile.Name = "UPDATED NAME";
            profile.Email = "updated@test.com";
            profile.ShowProfileForAnonymous = false;
            profile.PublicPresentationText =
                "[PublicPresentationText] UPDATED Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. Some more words.";
            profile.PrivatePresentationText =
                "[PrivatePresentationText] UPDATED Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. Some more words.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut at massa dolor. Nulla volutpat nisi et mi scelerisque, eget iaculis risus tristique. Morbi at tellus ligula. Integer vestibulum accumsan diam eget ullamcorper. Suspendisse dapibus est in porttitor finibus. Curabitur dictum risus nec ligula lacinia porta. Duis convallis eleifend mi id auctor. Some more words. Some more words.";
            profile.ImagePath = "UPDATED.jpg";

            _repo.UpdateProfile(profile);
            _repo.Save();


            // Assert
            Assert.AreEqual(profile.PublicPresentationText, _repo.GetProfile().PublicPresentationText);
        }

    }
}