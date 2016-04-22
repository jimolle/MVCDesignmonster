using System.Collections.Generic;
using System.Linq;
using MVCDesignmonster.BusinessObjects.Models;
using MVCDesignmonster.BusinessObjects.Repository;

namespace MVCDesignmonster.Test.Fakes
{
    public class FakeStartPageRepository : IStartpageRepository
    {
        private HashSet<Startpage> _context = new HashSet<Startpage>();

        public FakeStartPageRepository()
        {
            var fakeStartpage = new Startpage()
            {
                StartpageId = 1,
                WelcomeTitle = "WelcomeTitleTest",
                WelcomeText = "WelcomeTextTest"
            };
            _context.Add(fakeStartpage);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Startpage GetStartpage()
        {
            return _context.First();
        }

        public void UpdateStartpage(Startpage startpage)
        {
            _context.First().WelcomeTitle = startpage.WelcomeTitle;
            _context.First().WelcomeText = startpage.WelcomeText;
        }

        public void Save()
        {
            //Do nothing
        }
    }
}