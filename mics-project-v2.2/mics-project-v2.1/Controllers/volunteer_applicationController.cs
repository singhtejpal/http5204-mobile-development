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
    public class volunteer_applicationController : Controller
    {
        private HospitalDatabaseContext db = new HospitalDatabaseContext();

        // GET: volunteer_application
        public ActionResult Index()
        {
            return View(db.tbl_volunteer_application.ToList());
        }

        public ActionResult thnakuser()
        {
            //tbl_volunteer_application tbl_volunteer_application = new tbl_volunteer_application();
            //string applicant = tbl_volunteer_application.full_name;
           //string message =  "Thank you for your application " + applicant + ". You will be contacte by our staff.";
            return View();
        }

        // GET: volunteer_application/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_volunteer_application tbl_volunteer_application = db.tbl_volunteer_application.Find(id);
            if (tbl_volunteer_application == null)
            {
                return HttpNotFound();
            }
            return View(tbl_volunteer_application);
        }

        // GET: volunteer_application/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
            var posting = db.tbl_volunteer_posting.Find(id);
            ViewBag.ApplicationId = id;
            ViewBag.ApplicationPosition = posting.title;
            return View();
        }

        // POST: volunteer_application/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,full_name,age,gender,address,posting_id")] tbl_volunteer_application tbl_volunteer_application)
        {
            int isAgreeFromForm = 0;
            string isAgree = Request.Form.Get("Is_agree");
            if(isAgree == "on")
            {
                isAgreeFromForm = 1;
            }
            else
            {
                isAgreeFromForm = 0;
            }

            //            string test = Request.Form.Get("Is_agree");
            if (isAgreeFromForm == 0)
            {
                ModelState.AddModelError("Is_agree", "Please check the agreement");
            } else
            {
                if (ModelState.IsValid)
                {
                    tbl_volunteer_application.date = DateTime.Now;
                    tbl_volunteer_application.Is_agree = Convert.ToByte(isAgreeFromForm);
                    db.tbl_volunteer_application.Add(tbl_volunteer_application);
                    db.SaveChanges();
                    return RedirectToAction("thnakuser");
                }
            }

            int postingId = Convert.ToInt32(Request.Form.Get("posting_id"));
            var posting = db.tbl_volunteer_posting.Find(postingId);
            ViewBag.ApplicationId = postingId;
            ViewBag.ApplicationPosition = posting.title;
            return View(tbl_volunteer_application);
        }

        // GET: volunteer_application/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_volunteer_application tbl_volunteer_application = db.tbl_volunteer_application.Find(id);
            if (tbl_volunteer_application == null)
            {
                return HttpNotFound();
            }
            return View(tbl_volunteer_application);
        }

        // POST: volunteer_application/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,full_name,age,gender,address,date")] tbl_volunteer_application tbl_volunteer_application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_volunteer_application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_volunteer_application);
        }

        // GET: volunteer_application/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_volunteer_application tbl_volunteer_application = db.tbl_volunteer_application.Find(id);
            if (tbl_volunteer_application == null)
            {
                return HttpNotFound();
            }
            return View(tbl_volunteer_application);
        }

        // POST: volunteer_application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_volunteer_application tbl_volunteer_application = db.tbl_volunteer_application.Find(id);
            db.tbl_volunteer_application.Remove(tbl_volunteer_application);
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
