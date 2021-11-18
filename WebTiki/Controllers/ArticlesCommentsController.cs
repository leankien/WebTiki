using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTiki.Models;

namespace WebTiki.Controllers
{
    public class ArticlesCommentsController : Controller
    {
        private SQLSanPhamEntities db = new SQLSanPhamEntities();

        // GET: ArticlesComments
        public ActionResult Index()
        {
            return View(db.ArticlesComments.ToList());
        }

        // GET: ArticlesComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesComments articlesComments = db.ArticlesComments.Find(id);
            if (articlesComments == null)
            {
                return HttpNotFound();
            }
            return View(articlesComments);
        }

        // GET: ArticlesComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticlesComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Comments,ThisDateTime,ArticleId,Rating")] ArticlesComments articlesComments)
        {
            if (ModelState.IsValid)
            {
                db.ArticlesComments.Add(articlesComments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articlesComments);
        }

        // GET: ArticlesComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesComments articlesComments = db.ArticlesComments.Find(id);
            if (articlesComments == null)
            {
                return HttpNotFound();
            }
            return View(articlesComments);
        }

        // POST: ArticlesComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Comments,ThisDateTime,ArticleId,Rating")] ArticlesComments articlesComments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articlesComments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articlesComments);
        }

        // GET: ArticlesComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticlesComments articlesComments = db.ArticlesComments.Find(id);
            if (articlesComments == null)
            {
                return HttpNotFound();
            }
            return View(articlesComments);
        }

        // POST: ArticlesComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticlesComments articlesComments = db.ArticlesComments.Find(id);
            db.ArticlesComments.Remove(articlesComments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
