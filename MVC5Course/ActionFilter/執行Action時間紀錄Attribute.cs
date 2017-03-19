﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    public class 執行Action時間紀錄Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.StartTime = DateTime.Now;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.EndTime = DateTime.Now;
            filterContext.Controller.ViewBag.Duration = 
                filterContext.Controller.ViewBag.EndTime - filterContext.Controller.ViewBag.StartTime;
        }
    }
}