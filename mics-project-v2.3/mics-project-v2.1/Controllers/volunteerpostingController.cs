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
    public class volunteerpostingController : Controller
    {
        private HospitalDatabaseContext db = new HospitalDatabaseContext();

        // GET: volunteerposting
        public ActionResult Index()
        {
            var tbl_volunteer_posting = db.tbl_volunteer_posting.Include(t => t.tbl_admin);
            return View(tbl_volunteer_posting.ToList());
        }

        public ActionResult listallposting()
        {
            var postinglist = db.tbl_volunteer_posting.ToList();
            return View(postinglist);
        }

        public ActionResult viewoneposting(int? id)
        {
            List<tbl_volunteer_posting> result = (from e in db.tbl_volunteer_posting
                         where (e.Id ==(int) id)
                         select e).ToList();
            var oneResult = db.tbl_volunteer_posting.Find(id);
            return View(oneResult);
        }

        // GET: volunteerposting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_volunteer_posting tbl_volunteer_posting = db.tbl_volunteer_posting.Find(id);
            if (tbl_volunteer_posting == null)
            {
                return HttpNotFound();
            }
            return View(tbl_volunteer_posting);
        }

        // GET: volunteerposting/Create
        public ActionResult Create(int? id)
        {
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name");
            return View();
        }

        // POST: volunteerposting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,title,content,admin_id")] tbl_volunteer_posting tbl_volunteer_posting)
        {
            if (ModelState.IsValid)
            {
                tbl_volunteer_posting.date_created = DateTime.Now;
                db.tbl_volunteer_posting.Add(tbl_volunteer_posting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_volunteer_posting.admin_id);
            return View(tbl_volunteer_posting);
        }

        // GET: volunteerposting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_volunteer_posting tbl_volunteer_posting = db.tbl_volunteer_posting.Find(id);
            if (tbl_volunteer_posting == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_volunteer_posting.admin_id);
            return View(tbl_volunteer_posting);
        }

        // POST: volunteerposting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title,content,admin_id,date_created")] tbl_volunteer_posting tbl_volunteer_posting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_volunteer_posting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_id = new SelectList(db.tbl_admin, "Id", "first_name", tbl_volunteer_posting.admin_id);
            return View(tbl_volunteer_posting);
        }

        // GET: volunteerposting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_volunteer_posting tbl_volunteer_posting = db.tbl_volunteer_posting.Find(id);
            if (tbl_volunteer_posting == null)
            {
                return HttpNotFound();
            }
            return View(tbl_volunteer_posting);
        }

        // POST: volunteerposting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_volunteer_posting tbl_volunteer_posting = db.tbl_volunteer_posting.Find(id);
            db.tbl_volunteer_posting.Remove(tbl_volunteer_posting);
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
