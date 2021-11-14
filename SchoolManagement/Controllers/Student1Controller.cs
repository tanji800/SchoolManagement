using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class Student1Controller : Controller
    {
        private SchoolManagement_DBEntities3 db = new SchoolManagement_DBEntities3();

        // GET: Student1
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View(await db.Student1.ToListAsync());
        }

        // GET: Student1/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student1 student1 = await db.Student1.FindAsync(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }
            return View(student1);
        }

        // GET: Student1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate")] Student1 student1)
        {
            if (ModelState.IsValid)
            {
                db.Student1.Add(student1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(student1);
        }

        // GET: Student1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student1 student1 = await db.Student1.FindAsync(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }
            return View(student1);
        }

        // POST: Student1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentID,LastName,FirstName,EnrollmentDate,MiddleName")] Student1 student1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student1).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student1);
        }

        // GET: Student1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student1 student1 = await db.Student1.FindAsync(id);
            if (student1 == null)
            {
                return HttpNotFound();
            }
            return View(student1);
        }

        // POST: Student1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student1 student1 = await db.Student1.FindAsync(id);
            db.Student1.Remove(student1);
            await db.SaveChangesAsync();
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
