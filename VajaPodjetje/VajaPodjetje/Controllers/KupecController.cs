using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VajaPodjetje.Data;
using VajaPodjetje.Models;

namespace VajaPodjetje.Controllers
{
    public class KupecController : Controller
    {
        private PodjetjeContext db = new PodjetjeContext();

        // GET: Kupec
        public ActionResult Index()
        {
            return View(db.Kupecs.ToList());
        }

        // GET: Kupec/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupec kupec = db.Kupecs.Find(id);
            if (kupec == null)
            {
                return HttpNotFound();
            }
            return View(kupec);
        }

        // GET: Kupec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kupec/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ImePodjetja,Kontakt,Telefon,Mail")] Kupec kupec)
        {
            if (ModelState.IsValid)
            {
                db.Kupecs.Add(kupec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kupec);
        }

        // GET: Kupec/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupec kupec = db.Kupecs.Find(id);
            if (kupec == null)
            {
                return HttpNotFound();
            }
            return View(kupec);
        }

        // POST: Kupec/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ImePodjetja,Kontakt,Telefon,Mail")] Kupec kupec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kupec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kupec);
        }

        // GET: Kupec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupec kupec = db.Kupecs.Find(id);
            if (kupec == null)
            {
                return HttpNotFound();
            }
            return View(kupec);
        }

        // POST: Kupec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kupec kupec = db.Kupecs.Find(id);
            db.Kupecs.Remove(kupec);
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
