using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using PagedList;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        //private FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index(string sortBy,string keyword,int PageNo = 1)
        {
            DoSearchToIndex(sortBy, keyword, PageNo);

            return View();
        }

        private void DoSearchToIndex(string sortBy, string keyword, int PageNo)
        {
            var allData = repoProduct.All().AsQueryable();

            if (!String.IsNullOrEmpty(keyword))
            {
                allData = allData.Where(p => p.ProductName.Contains(keyword));
            }

            if (sortBy == "+price")
            {
                allData = allData.OrderBy(p => p.Price);
            }
            else
            {
                allData = allData.OrderByDescending(p => p.Price);
            }

            ViewBag.keyword = keyword;
            ViewData.Model = allData.ToPagedList(PageNo, 10);
        }

        [HttpPost]
        public ActionResult Index(Product[] data, string sortBy, string keyword, int PageNo = 1)
        {
            if(ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var oldData = repoProduct.Find(item.ProductId);
                    oldData.ProductName = item.ProductName;
                    oldData.Price = item.Price;
                    oldData.Active = item.Active;
                    oldData.Stock = item.Stock;
                }
                repoProduct.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            DoSearchToIndex(sortBy, keyword, PageNo);

            return View();
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repoProduct.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repoProduct.Add(product);
                repoProduct.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repoProduct.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(View= "Error_DbEntityValidationException", ExceptionType = typeof(DbEntityValidationException))]
        public ActionResult Edit(int id,FormCollection form)
        {
            var product = repoProduct.Find(id);
            if (TryUpdateModel(product,new string[] { "ProductName","Stock"}))
            {
                //var db = repoProduct.UnitOfWork.Context;
                //db.Entry(product).State = EntityState.Modified;
            }
            repoProduct.UnitOfWork.Commit();
            return RedirectToAction("Index");
            //return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repoProduct.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repoProduct.Find(id);
            repoProduct.Delete(product);
            repoProduct.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
