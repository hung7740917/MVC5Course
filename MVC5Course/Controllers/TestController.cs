using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            return View("123");
        }

        public ActionResult View2()
        {
            return PartialView("Index");
        }

        public ActionResult View3()
        {
            return View();
        }

        public ActionResult File()
        {
            //return File(@"C:\Users\Admin\Desktop\MVC5\MVC5Course\MVC5Course\Content\ball.png", "image/png");
            return File(Server.MapPath("~/Content/ball.png"), "image/png");
        }

        public ActionResult File2()
        {
            //return File(@"C:\Users\Admin\Desktop\MVC5\MVC5Course\MVC5Course\Content\ball.png", "image/png");
            return File(Server.MapPath("~/Content/ball.png"), "image/png","myBall.png");
        }
    }
}