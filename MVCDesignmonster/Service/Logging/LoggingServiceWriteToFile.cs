using System;
using System.IO;
using System.Web;

namespace MVCDesignmonster.Service.Logging
{
    public class LoggingServiceWriteToFile : ILoggingService
    {
        public void Log(LoggingViewModel loggingViewModel)
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/logg.txt");

            // TODO Denna överhettar ju då och då... kolla upp
            using (var fs = new FileStream(path, FileMode.Append))
            using (var sw = new StreamWriter(fs))
            {
                sw.Write($"RawUrl: {loggingViewModel.RawUrl} UserName: {loggingViewModel.UserName} " +
                         $"TimeStamp: {loggingViewModel.TimeStamp}" + Environment.NewLine);
            }
        }

        public void Dispose()
        {
            // Här borde vi aldrig hamna...
            throw new NotImplementedException();
        }
    }
}
