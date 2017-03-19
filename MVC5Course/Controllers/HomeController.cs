using MVC5Course.ActionFilter;
using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [常用ViewBag設定]
        [HandleError(View = "Error_ArgumentException", ExceptionType = typeof(ArgumentException))]
        public ActionResult About(int ex)
        {

            if(ex == 1)
            {
                throw new Exception("ex");
            }

            return View();
        }
        [僅在本機開發測試使用]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page test.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Login(string ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM,string ReturnUrl = "")
        {
            if(ModelState.IsValid)
            {
                FormsAuthentication.RedirectFromLoginPage(loginVM.Username,false);
                TempData["LoginResult"] = loginVM;
                if (ReturnUrl.StartsWith("/"))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        
    }
}