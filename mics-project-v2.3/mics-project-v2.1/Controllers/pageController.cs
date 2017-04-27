using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mics_project_v2._1.Models;

namespace mics_project_v2._1.Controllers
{
    public class pageController : Controller
    {
        private HospitalDatabaseContext db = new HospitalDatabaseContext();

        public PartialViewResult test()
        {
            var model = db.tbl_page.ToList();
            return PartialView("_NavPartial",model);
        }

        // GET: page
        public ActionResult Index()
        {
            var tbl_page = db.tbl_page.Include(t => t.tbl_admin);
            return View(tbl_page.ToList());
        }

        // GET: page/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_page tbl_page = db.tbl_page.Find(id);
            if (tbl_page == null)
            {
                return HttpNotFound();
            }
            return View(tbl_page);
        }

        // GET: page/Create
        public ActionResult Create()
        {
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name");
            return View();
        }

        // POST: page/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,content,admin_id")] tbl_page tbl_page)
        {
            if (ModelState.IsValid)
            {
                db.tbl_page.Add(tbl_page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_page.admin_id);
            return View(tbl_page);
        }

        // GET: page/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_page tbl_page = db.tbl_page.Find(id);
            if (tbl_page == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_page.admin_id);
            return View(tbl_page);
        }

        // POST: page/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,content,admin_id")] tbl_page tbl_page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_page.admin_id);
            return View(tbl_page);
        }

        // GET: page/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_page tbl_page = db.tbl_page.Find(id);
            if (tbl_page == null)
            {
                return HttpNotFound();
            }
            return View(tbl_page);
        }

        // POST: page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_page tbl_page = db.tbl_page.Find(id);
            db.tbl_page.Remove(tbl_page);
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
