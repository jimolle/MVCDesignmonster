using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace MVCDesignmonster.Service
{
    public class SmsFakeService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Printing to debug output window...
            Debug.WriteLine(message.Body);

            return Task.FromResult(0);
        }
    }
}
