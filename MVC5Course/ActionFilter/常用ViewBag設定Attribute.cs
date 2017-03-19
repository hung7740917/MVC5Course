using System;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    public class 常用ViewBag設定Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.";
        }
    }
}