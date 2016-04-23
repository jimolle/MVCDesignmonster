using System;
using MVCDesignmonster.BusinessObjects.Models;

namespace MVCDesignmonster.BusinessObjects.Repository
{
    public abstract class RepoBase : IDisposable
    {
        private ProfileDbContext _dataContext;

        // TODO you _REALLY_ need a DisposedTracker,
        // annars öppnar den en ny kontext bara för att sen stänga den på varje repo!
        // -> Det gör den fortfarande, kör UoW!

        //DataContext, only one instance
        protected ProfileDbContext DataContext
        {
            get
            {
                {
                    if (_dataContext == null)
                        _dataContext = new ProfileDbContext();
                }
                return _dataContext;
            }
        }


        public void Dispose()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }
}