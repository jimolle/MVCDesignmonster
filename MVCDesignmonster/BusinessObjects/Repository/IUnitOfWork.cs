using System;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IProfileRepository ProfileRepository { get; }
        IEducationRepository EducationRepository { get; }
        IEmployerRepository EmployerRepository { get; }

        IStartpageRepository StartpageRepository { get; }

        ILogRepository LogRepository { get; }

        void Save();
    }
}