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
    public class RacunController : Controller
    {
        private PodjetjeContext db = new PodjetjeContext();

        // GET: Racun
        public ActionResult Index()
        {
            var racuns = db.Racuns.Include(r => r.Kupec);
            return View(racuns.ToList());
        }

        // GET: Racun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuns.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // GET: Racun/Create
        public ActionResult Create()
        {
            ViewBag.KupecId = new SelectList(db.Kupecs, "Id", "ImePodjetja");
            return View();
        }

        // POST: Racun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vrednost,DatumIzdaje,KupecId")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Racuns.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KupecId = new SelectList(db.Kupecs, "Id", "ImePodjetja", racun.KupecId);
            return View(racun);
        }

        // GET: Racun/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuns.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            ViewBag.KupecId = new SelectList(db.Kupecs, "Id", "ImePodjetja", racun.KupecId);
            return View(racun);
        }

        // POST: Racun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vrednost,DatumIzdaje,KupecId")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KupecId = new SelectList(db.Kupecs, "Id", "ImePodjetja", racun.KupecId);
            return View(racun);
        }

        // GET: Racun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racuns.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Racun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racun racun = db.Racuns.Find(id);
            db.Racuns.Remove(racun);
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
