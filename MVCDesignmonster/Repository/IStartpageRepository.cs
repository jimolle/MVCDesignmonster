using System;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public interface IStartpageRepository : IDisposable
    {
        Startpage GetStartpage();
        void UpdateStartpage(Startpage startpage);
        void Save();
    }
}