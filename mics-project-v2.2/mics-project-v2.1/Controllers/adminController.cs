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
    public class adminController : Controller
    {
        private HospitalDatabaseContext db = new HospitalDatabaseContext();

        // GET: admin
        public ActionResult Index()
        {
            return View(db.tbl_admin.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tbl_admin a)
        {
            //to handle post
            if (ModelState.IsValid)
            {
                using (HospitalDatabaseContext db = new HospitalDatabaseContext())
                {
                    var v = db.tbl_admin.Where(u => u.first_name.Equals(a.first_name) && u.password.Equals(a.password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LoggedInUserFirstName"] = v.first_name.ToString();
                        Session["LoggedInUserPassword"] = v.password.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(a);
        }

        public ActionResult AfterLogin()
        {
            if(Session["LoggedInUserFirstName"] != null)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }

        // GET: admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = db.tbl_admin.Find(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_admin);
        }

        // GET: admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,first_name,last_name,password")] tbl_admin tbl_admin)
        {
            if (ModelState.IsValid)
            {
                db.tbl_admin.Add(tbl_admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_admin);
        }

        // GET: admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = db.tbl_admin.Find(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_admin);
        }

        // POST: admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,first_name,last_name,password")] tbl_admin tbl_admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_admin);
        }

        // GET: admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = db.tbl_admin.Find(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_admin);
        }

        // POST: admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_admin tbl_admin = db.tbl_admin.Find(id);
            db.tbl_admin.Remove(tbl_admin);
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
