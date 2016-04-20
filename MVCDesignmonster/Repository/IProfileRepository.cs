using System;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public interface IProfileRepository : IDisposable
    {
        Profile GetProfile();
        void UpdateProfile(Profile profile);
        void Save();
    }
}