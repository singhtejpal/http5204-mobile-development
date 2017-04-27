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
    public class primary_navController : Controller
    {
        private HospitalDatabaseContext db = new HospitalDatabaseContext();

        // GET: primary_nav
        public ActionResult Index()
        {
            var tbl_primary_nav = db.tbl_primary_nav.Include(t => t.tbl_admin);
            return View(tbl_primary_nav.ToList());
        }

        // GET: primary_nav/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_primary_nav tbl_primary_nav = db.tbl_primary_nav.Find(id);
            if (tbl_primary_nav == null)
            {
                return HttpNotFound();
            }
            return View(tbl_primary_nav);
        }

        // GET: primary_nav/Create
        public ActionResult Create()
        {
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name");
            return View();
        }

        // POST: primary_nav/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,admin_id")] tbl_primary_nav tbl_primary_nav)
        {
            if (ModelState.IsValid)
            {
                db.tbl_primary_nav.Add(tbl_primary_nav);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_primary_nav.admin_id);
            return View(tbl_primary_nav);
        }

        // GET: primary_nav/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_primary_nav tbl_primary_nav = db.tbl_primary_nav.Find(id);
            if (tbl_primary_nav == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_primary_nav.admin_id);
            return View(tbl_primary_nav);
        }

        // POST: primary_nav/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,admin_id")] tbl_primary_nav tbl_primary_nav)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_primary_nav).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_primary_nav.admin_id);
            return View(tbl_primary_nav);
        }

        // GET: primary_nav/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_primary_nav tbl_primary_nav = db.tbl_primary_nav.Find(id);
            if (tbl_primary_nav == null)
            {
                return HttpNotFound();
            }
            return View(tbl_primary_nav);
        }

        // POST: primary_nav/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_primary_nav tbl_primary_nav = db.tbl_primary_nav.Find(id);
            db.tbl_primary_nav.Remove(tbl_primary_nav);
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
