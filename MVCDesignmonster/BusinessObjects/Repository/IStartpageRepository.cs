using System;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public interface IStartpageRepository : IDisposable
    {
        Startpage GetStartpage();
        void UpdateStartpage(Startpage startpage);
        void Save();
    }
}