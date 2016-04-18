using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDesignmonster.Repository.WithBaseclass
{
    public interface IDisposedTracker
    {
        bool IsDisposed { get; set; }
    }
}
