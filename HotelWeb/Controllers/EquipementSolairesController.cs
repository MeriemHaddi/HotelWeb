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
    public class EquipementSolairesController : Controller
    {
        private MyDBContextHotel db = new MyDBContextHotel();

        // GET: EquipementSolaires
        public ActionResult Index()
        {
            return View(db.DbSetEquipementSolaire.ToList());
        }

        // GET: EquipementSolaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipementSolaire equipementSolaire = db.DbSetEquipementSolaire.Find(id);
            if (equipementSolaire == null)
            {
                return HttpNotFound();
            }
            return View(equipementSolaire);
        }

        // GET: EquipementSolaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipementSolaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipementId,nom,code,debit,consommation,coeff")] EquipementSolaire equipementSolaire)
        {
            if (ModelState.IsValid)
            {
                db.DbSetEquipement.Add(equipementSolaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipementSolaire);
        }

        // GET: EquipementSolaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipementSolaire equipementSolaire = db.DbSetEquipementSolaire.Find(id);
            if (equipementSolaire == null)
            {
                return HttpNotFound();
            }
            return View(equipementSolaire);
        }

        // POST: EquipementSolaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipementId,nom,code,debit,consommation,coeff")] EquipementSolaire equipementSolaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipementSolaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipementSolaire);
        }

        // GET: EquipementSolaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipementSolaire equipementSolaire = db.DbSetEquipementSolaire.Find(id);
            if (equipementSolaire == null)
            {
                return HttpNotFound();
            }
            return View(equipementSolaire);
        }

        // POST: EquipementSolaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipementSolaire equipementSolaire = db.DbSetEquipementSolaire.Find(id);
            db.DbSetEquipement.Remove(equipementSolaire);
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
