using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mics_project_v2._1.Models;
using System.IO;

namespace mics_project_v2._1.Controllers
{
    public class newsletterController : Controller
    {
        private HospitalDatabaseContext db = new HospitalDatabaseContext();

        // GET: newsletter
        public ActionResult Index()
        {
            var tbl_newsletter = db.tbl_newsletter.Include(t => t.tbl_admin);
            return View(tbl_newsletter.ToList());
        }

        // GET: newsletter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_newsletter tbl_newsletter = db.tbl_newsletter.Find(id);
            if (tbl_newsletter == null)
            {
                return HttpNotFound();
            }
            return View(tbl_newsletter);
        }

        public ActionResult ViewAllNewsletters()
        {
            var allnewsletters = db.tbl_newsletter.ToList();
            return View(allnewsletters);
        }

        public ActionResult ViewOneNewsletter(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_newsletter onenewsletter = db.tbl_newsletter.Find(id);
            if (onenewsletter == null)
            {
                return HttpNotFound();
            }
            return View(onenewsletter);
        }

        // GET: newsletter/Create
        public ActionResult Create()
        {
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name");
            return View();
        }

        // POST: newsletter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,heading,content,admin_id")] tbl_newsletter tbl_newsletter,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var filename = Path.GetFileName(file.FileName);
                    tbl_newsletter.image = filename;
                    var path = Path.Combine(Server.MapPath("~/images/"),filename);
                    file.SaveAs(path);
                }
                db.tbl_newsletter.Add(tbl_newsletter);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_newsletter.admin_id);
            return View(tbl_newsletter);
        }

        // GET: newsletter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_newsletter tbl_newsletter = db.tbl_newsletter.Find(id);
            if (tbl_newsletter == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_newsletter.admin_id);
            return View(tbl_newsletter);
        }

        // POST: newsletter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,heading,content,image,admin_id")] tbl_newsletter tbl_newsletter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_newsletter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_newsletter.admin_id);
            return View(tbl_newsletter);
        }

        // GET: newsletter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_newsletter tbl_newsletter = db.tbl_newsletter.Find(id);
            if (tbl_newsletter == null)
            {
                return HttpNotFound();
            }
            return View(tbl_newsletter);
        }

        // POST: newsletter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_newsletter tbl_newsletter = db.tbl_newsletter.Find(id);
            db.tbl_newsletter.Remove(tbl_newsletter);
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
