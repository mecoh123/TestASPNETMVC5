using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestWeb2.Models;

namespace TestWeb2.Controllers
{
    public class UserController : Controller
    {
        private PersonalContext db = new PersonalContext();

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await db.Personal.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,LastName,FirstName,MiddleName")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Personal.Add(personal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(personal);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,LastName,FirstName,MiddleName")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(personal);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Personal personal = await db.Personal.FindAsync(id);
            db.Personal.Remove(personal);
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
