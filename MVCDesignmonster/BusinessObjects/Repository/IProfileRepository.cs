using System;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public interface IProfileRepository : IDisposable
    {
        Profile GetProfile();
        void UpdateProfile(Profile profile);
        //void Save();
    }
}