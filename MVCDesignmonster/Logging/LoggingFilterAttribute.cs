using System;
using System.Web;
using System.Web.Mvc;

namespace MVCDesignmonster.Logging
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

                var loggingVM = new LoggingViewModel()
                {
                    Action = filterContext.ActionDescriptor.ActionName,
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    UserName = userName,
                    TimeStamp = DateTime.Now
                };

                var logger = new LoggingServiceWriteToFile();
                logger.Log(loggingVM);
            }
        }
    }
}