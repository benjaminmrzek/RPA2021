using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vaja.Data;
using Vaja.Models;

namespace Vaja.Controllers
{
    public class FilmiController : Controller
    {
        private VajaContext db = new VajaContext();
        public ActionResult Isci(string niz, string ftip)
        {
            //izdelaj seznam vseh tipov
            var tipi = new List<string>();
            var seznam = from d in db.Films
                         orderby d.Tip
                         select d.Tip;
            tipi.AddRange(seznam.Distinct());
            ViewBag.ftip = new SelectList(tipi);
            //filtriraj po nizu v naslovu filma
            var filmi = from a in db.Films
                        select a;
            if (!String.IsNullOrEmpty(niz))
            {
                filmi = filmi.Where(s => s.Naslov.Contains(niz));
            }
            //filtriraj po tipu
            if (!String.IsNullOrEmpty(ftip))
                filmi = filmi.Where(s => s.Tip == ftip);
            return View(filmi);
        }
        // GET: Filmi
        public ActionResult Index()
        {
            return View(db.Films.ToList());
        }

        // GET: Filmi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Filmi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filmi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naslov,Izdano,Tip,Cena")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(film);
        }

        // GET: Filmi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Filmi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naslov,Izdano,Tip,Cena")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Filmi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Filmi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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
