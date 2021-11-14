using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class COURSEsController : Controller
    {
        private SchoolManagement_DBEntities3 db = new SchoolManagement_DBEntities3();

        // GET: COURSEs
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.COURSEs.ToList());
        }

        // GET: COURSEs/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        // GET: COURSEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COURSEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits")] COURSE cOURSE)
        {
            if (ModelState.IsValid)
            {
                db.COURSEs.Add(cOURSE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cOURSE);
        }

        // GET: COURSEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        // POST: COURSEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits")] COURSE cOURSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOURSE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cOURSE);
        }

        // GET: COURSEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COURSE cOURSE = db.COURSEs.Find(id);
            if (cOURSE == null)
            {
                return HttpNotFound();
            }
            return View(cOURSE);
        }

        // POST: COURSEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COURSE cOURSE = db.COURSEs.Find(id);
            db.COURSEs.Remove(cOURSE);
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
