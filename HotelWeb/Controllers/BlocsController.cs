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
    public class BlocsController : Controller
    {
        private MyDBContextHotel db = new MyDBContextHotel();

        // GET: Blocs
        public ActionResult Index()
        {
            return View(db.DbSetBloc.ToList());
        }

        // GET: Blocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloc bloc = db.DbSetBloc.Find(id);
            if (bloc == null)
            {
                return HttpNotFound();
            }
            return View(bloc);
        }

        // GET: Blocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlocId,numero,responsable")] Bloc bloc)
        {
            if (ModelState.IsValid)
            {
                db.DbSetBloc.Add(bloc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloc);
        }

        // GET: Blocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloc bloc = db.DbSetBloc.Find(id);
            if (bloc == null)
            {
                return HttpNotFound();
            }
            return View(bloc);
        }

        // POST: Blocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlocId,numero,responsable")] Bloc bloc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloc);
        }

        // GET: Blocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloc bloc = db.DbSetBloc.Find(id);
            if (bloc == null)
            {
                return HttpNotFound();
            }
            return View(bloc);
        }

        // POST: Blocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloc bloc = db.DbSetBloc.Find(id);
            db.DbSetBloc.Remove(bloc);
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
