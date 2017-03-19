﻿using System;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    public class 僅在本機開發測試使用Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}