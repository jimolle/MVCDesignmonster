using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace MVCDesignmonster.Service.FakeSmsService
{
    public class FakeSmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Printing to debug output window...
            Debug.WriteLine(message.Body);

            return Task.FromResult(0);
        }
    }
}
