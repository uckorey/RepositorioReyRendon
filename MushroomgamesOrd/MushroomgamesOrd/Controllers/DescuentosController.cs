using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MushroomgamesOrd;

namespace MushroomgamesOrd.Controllers
{
    public class DescuentosController : Controller
    {
        private MushroomgamesDBEntities db = new MushroomgamesDBEntities();

        // GET: Descuentos
        public ActionResult Index()
        {
            var descuentos = db.Descuentos.Include(d => d.Juego);
            return View(descuentos.ToList());
        }

        // GET: Descuentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuentos descuentos = db.Descuentos.Find(id);
            if (descuentos == null)
            {
                return HttpNotFound();
            }
            return View(descuentos);
        }

        // GET: Descuentos/Create
        public ActionResult Create()
        {
            ViewBag.id_Juego = new SelectList(db.Juego, "id_Juego", "nombre_Juego");
            return View();
        }

        // POST: Descuentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Descuento,nombre_Descuento,cantidad_Descuento,id_Juego")] Descuentos descuentos)
        {
            if (ModelState.IsValid)
            {
                db.Descuentos.Add(descuentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Juego = new SelectList(db.Juego, "id_Juego", "nombre_Juego", descuentos.id_Juego);
            return View(descuentos);
        }

        // GET: Descuentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuentos descuentos = db.Descuentos.Find(id);
            if (descuentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Juego = new SelectList(db.Juego, "id_Juego", "nombre_Juego", descuentos.id_Juego);
            return View(descuentos);
        }

        // POST: Descuentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Descuento,nombre_Descuento,cantidad_Descuento,id_Juego")] Descuentos descuentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Juego = new SelectList(db.Juego, "id_Juego", "nombre_Juego", descuentos.id_Juego);
            return View(descuentos);
        }

        // GET: Descuentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuentos descuentos = db.Descuentos.Find(id);
            if (descuentos == null)
            {
                return HttpNotFound();
            }
            return View(descuentos);
        }

        // POST: Descuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Descuentos descuentos = db.Descuentos.Find(id);
            db.Descuentos.Remove(descuentos);
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
