using System;
using System.IO;
using System.Web;

namespace MVCDesignmonster.Logging
{
    public class LoggingServiceWriteToFile : ILoggingService
    {
        public void Log(LoggingViewModel loggingViewModel)
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/logg.txt");

            using (var fs = new FileStream(path, FileMode.Append))
            using (var sw = new StreamWriter(fs))
            {
                sw.Write($"Controller: {loggingViewModel.Controller} Action: {loggingViewModel.Action} UserName: {loggingViewModel.UserName} " +
                         $"TimeStamp: {loggingViewModel.TimeStamp}" + Environment.NewLine);
            }
        }
    }
}
