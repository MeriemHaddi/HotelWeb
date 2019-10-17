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
    public class EquipementElectriquesController : Controller
    {
        private MyDBContextHotel db = new MyDBContextHotel();

        // GET: EquipementElectriques
        public ActionResult Index()
        {
            return View(db.DbSetEquipementElectrique.ToList());
        }

        // GET: EquipementElectriques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipementElectrique equipementElectrique = db.DbSetEquipementElectrique.Find(id);
            if (equipementElectrique == null)
            {
                return HttpNotFound();
            }
            return View(equipementElectrique);
        }

        // GET: EquipementElectriques/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipementElectriques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipementId,nom,code,debit,consommation")] EquipementElectrique equipementElectrique)
        {
            if (ModelState.IsValid)
            {
                db.DbSetEquipement.Add(equipementElectrique);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipementElectrique);
        }

        // GET: EquipementElectriques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipementElectrique equipementElectrique = db.DbSetEquipementElectrique.Find(id);
            if (equipementElectrique == null)
            {
                return HttpNotFound();
            }
            return View(equipementElectrique);
        }

        // POST: EquipementElectriques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipementId,nom,code,debit,consommation")] EquipementElectrique equipementElectrique)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipementElectrique).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipementElectrique);
        }

        // GET: EquipementElectriques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipementElectrique equipementElectrique = db.DbSetEquipementElectrique.Find(id);
            if (equipementElectrique == null)
            {
                return HttpNotFound();
            }
            return View(equipementElectrique);
        }

        // POST: EquipementElectriques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipementElectrique equipementElectrique = db.DbSetEquipementElectrique.Find(id);
            db.DbSetEquipement.Remove(equipementElectrique);
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
