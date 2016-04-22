using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MVCDesignmonster.Service.Logging
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CheckForLogging(filterContext);

            base.OnActionExecuting(filterContext);
        }

        private void CheckForLogging(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.RequestType == "GET")
            {
                string userName = "Anonymous";
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    userName = HttpContext.Current.User.Identity.Name;

                // hårdkodat för att slippa statistik från admin
                //if (userName == "admin@admin.com")
                //    return;

                var loggingVM = new LoggingViewModel()
                {
                    Action = filterContext.ActionDescriptor.ActionName,
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    RawUrl = filterContext.HttpContext.Request.RawUrl,
                    UserName = userName,
                    TimeStamp = DateTime.Now
                };

                var listOfLoggers = new List<ILoggingService>()
                {
                    new LoggingServiceWriteToDb(),
                    new LoggingServiceWriteToFile()
                };

                foreach (var logger in listOfLoggers)
                {
                    logger.Log(loggingVM);
                }
                
            }
        }
    }
}