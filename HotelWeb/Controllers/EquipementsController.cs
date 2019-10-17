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
    public class EquipementsController : Controller
    {
        private MyDBContextHotel db = new MyDBContextHotel();

        // GET: Equipements
        public ActionResult Index()
        {
            return View(db.DbSetEquipement.ToList());
        }

        // GET: Equipements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement equipement = db.DbSetEquipement.Find(id);
            if (equipement == null)
            {
                return HttpNotFound();
            }
            return View(equipement);
        }

        // GET: Equipements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipementId,nom,code,debit,consommation")] Equipement equipement)
        {
            if (ModelState.IsValid)
            {
                db.DbSetEquipement.Add(equipement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipement);
        }

        // GET: Equipements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement equipement = db.DbSetEquipement.Find(id);
            if (equipement == null)
            {
                return HttpNotFound();
            }
            return View(equipement);
        }

        // POST: Equipements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipementId,nom,code,debit,consommation")] Equipement equipement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipement);
        }

        // GET: Equipements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipement equipement = db.DbSetEquipement.Find(id);
            if (equipement == null)
            {
                return HttpNotFound();
            }
            return View(equipement);
        }

        // POST: Equipements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipement equipement = db.DbSetEquipement.Find(id);
            db.DbSetEquipement.Remove(equipement);
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
