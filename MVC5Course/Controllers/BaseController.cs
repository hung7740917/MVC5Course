﻿using MVC5Course.ActionFilter;
using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [執行Action時間紀錄]
    public abstract class BaseController : Controller
    {
        public ProductRepository repoProduct = RepositoryHelper.GetProductRepository();

        //protected override void HandleUnknownAction(string actionName)
        //{
        //    //base.HandleUnknownAction(actionName);
        //    this.Redirect("/").ExecuteResult(this.ControllerContext);
        //}
    }
}