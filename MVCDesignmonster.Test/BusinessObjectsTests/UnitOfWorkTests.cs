//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MVCDesignmonster.BusinessObjects.Models;
//using MVCDesignmonster.BusinessObjects.Repository;
//using MVCDesignmonster.Test.Fakes;

//namespace MVCDesignmonster.Test.BusinessObjectsTests
//{
//    [TestClass]
//    public class UnitOfWorkTests
//    {
//        private IUnitOfWork _unitOfWork;

//        public UnitOfWorkTests()
//        {
//            _unitOfWork = new UnitOfWork();
//            //_unitOfWork = new FakeUnitOfWork();
//        }


//        [TestMethod]
//        public void GetStartpage()
//        {
//            // Arrange

//            // Act
//            Startpage item = _repo.GetStartpage();


//            // Assert
//            Assert.IsNotNull(item);
//        }

//        [TestMethod]
//        public void Update()
//        {
//            // Arrange
//            var startpage = _repo.GetStartpage();

//            // Act
//            var updated = "UPDATED";
//            startpage.WelcomeTitle = "UPDATED";
//            _repo.Save();


//            // Assert
//            Assert.AreEqual(updated, _repo.GetStartpage().WelcomeTitle);
//        }

//    }


//    // TODO får nog testa repos för sig! :D
//    public class FakeUnitOfWork : IUnitOfWork
//    {
//        //private List<What?> _context = new ProfileDbContext();
//        private IProfileRepository _profileRepo;
//        private IEducationRepository _educationRepo;
//        private IEmployerRepository _employerRepo;

//        private IStartpageRepository _startpageRepo;
//        private ILogRepository _logRepo;


//        public FakeUnitOfWork(IProfileRepository profileRepository, IEducationRepository educationRepository, IEmployerRepository employerRepository,
//    IStartpageRepository startpageRepository, ILogRepository logRepository)
//        {
//            _profileRepo = profileRepository;
//            _educationRepo = educationRepository;
//            _employerRepo = employerRepository;
//            _startpageRepo = startpageRepository;
//            _logRepo = logRepository;
//        }

//        public void Dispose()
//        {
//            throw new System.NotImplementedException();
//        }

//        public IProfileRepository ProfileRepository { get; }
//        public IEducationRepository EducationRepository { get; }
//        public IEmployerRepository EmployerRepository { get; }
//        public IStartpageRepository StartpageRepository { get; }
//        public ILogRepository LogRepository { get; }
//        public void Save()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
