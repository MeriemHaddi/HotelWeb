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
    public class HotellsController : Controller
    {
        private MyDBContextHotel db = new MyDBContextHotel();

        // GET: Hotells
        public ActionResult Index()
        {
            return View(db.DbSetHotel.ToList());
        }

        // GET: Hotells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotell hotell = db.DbSetHotel.Find(id);
            if (hotell == null)
            {
                return HttpNotFound();
            }
            return View(hotell);
        }

        // GET: Hotells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotellId,nom,adresse,numtel,dateouverture,mail,responsable")] Hotell hotell)
        {
            if (ModelState.IsValid)
            {
                db.DbSetHotel.Add(hotell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotell);
        }

        // GET: Hotells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotell hotell = db.DbSetHotel.Find(id);
            if (hotell == null)
            {
                return HttpNotFound();
            }
            return View(hotell);
        }

        // POST: Hotells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotellId,nom,adresse,numtel,dateouverture,mail,responsable")] Hotell hotell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotell);
        }

        // GET: Hotells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotell hotell = db.DbSetHotel.Find(id);
            if (hotell == null)
            {
                return HttpNotFound();
            }
            return View(hotell);
        }

        // POST: Hotells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotell hotell = db.DbSetHotel.Find(id);
            db.DbSetHotel.Remove(hotell);
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
