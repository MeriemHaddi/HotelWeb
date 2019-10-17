using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataHotel;
using DataHotel.Entite;

namespace HotelWeb.Controllers
{
    public class ChambresController : Controller
    {
        private MyDBContextHotel db = new MyDBContextHotel();

        // GET: Chambres
        public ActionResult Index()
        {
            return View(db.DbSetChambre.ToList());
        }

        // GET: Chambres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chambre chambre = db.DbSetChambre.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            return View(chambre);
        }

        // GET: Chambres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chambres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChambreId,numero,type")] Chambre chambre)
        {
            if (ModelState.IsValid)
            {
                db.DbSetChambre.Add(chambre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chambre);
        }

        // GET: Chambres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chambre chambre = db.DbSetChambre.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            return View(chambre);
        }

        // POST: Chambres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChambreId,numero,type")] Chambre chambre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chambre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chambre);
        }

        // GET: Chambres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chambre chambre = db.DbSetChambre.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            return View(chambre);
        }

        // POST: Chambres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chambre chambre = db.DbSetChambre.Find(id);
            db.DbSetChambre.Remove(chambre);
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
