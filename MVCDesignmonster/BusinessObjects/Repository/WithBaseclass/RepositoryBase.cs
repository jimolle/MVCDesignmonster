using System;

namespace MVCDesignmonster.BusinessObjects.Repository.WithBaseclass
{
    public abstract class RepositoryBase<TContext> : IDisposable
        where TContext: IDisposedTracker, new()
    {

        private TContext _DataContext;

        public virtual TContext DataContext
        {
            get
            {
                if (_DataContext == null || _DataContext.IsDisposed)
                {
                    _DataContext = new TContext();
                }
                return _DataContext;
            }
        }

        public void Dispose()
        {
            // TODO Hur lösa disposen??
            //if (DataContext != null)
            //    DataContext.Dispose();
        }
    }
}
