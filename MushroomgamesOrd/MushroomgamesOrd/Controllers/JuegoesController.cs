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
    public class JuegoesController : Controller
    {
        private MushroomgamesDBEntities db = new MushroomgamesDBEntities();

        // GET: Juegoes
        public ActionResult Index()
        {
            var juego = db.Juego.Include(j => j.Categoria).Include(j => j.Desarrolladora);
            return View(juego.ToList());
        }

        // GET: Juegoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // GET: Juegoes/Create
        public ActionResult Create()
        {
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id_Categoria", "nombre_Categoria");
            ViewBag.id_Desarrolladora = new SelectList(db.Desarrolladora, "id_Desarrolladora", "nombre_Desarrolladora");
            return View();
        }

        // POST: Juegoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Juego,nombre_Juego,precio_Juego,descripcion_Juego,tamanio_Juego,id_Categoria,id_Desarrolladora")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Juego.Add(juego);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Categoria = new SelectList(db.Categoria, "id_Categoria", "nombre_Categoria", juego.id_Categoria);
            ViewBag.id_Desarrolladora = new SelectList(db.Desarrolladora, "id_Desarrolladora", "nombre_Desarrolladora", juego.id_Desarrolladora);
            return View(juego);
        }

        // GET: Juegoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id_Categoria", "nombre_Categoria", juego.id_Categoria);
            ViewBag.id_Desarrolladora = new SelectList(db.Desarrolladora, "id_Desarrolladora", "nombre_Desarrolladora", juego.id_Desarrolladora);
            return View(juego);
        }

        // POST: Juegoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Juego,nombre_Juego,precio_Juego,descripcion_Juego,tamanio_Juego,id_Categoria,id_Desarrolladora")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juego).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Categoria = new SelectList(db.Categoria, "id_Categoria", "nombre_Categoria", juego.id_Categoria);
            ViewBag.id_Desarrolladora = new SelectList(db.Desarrolladora, "id_Desarrolladora", "nombre_Desarrolladora", juego.id_Desarrolladora);
            return View(juego);
        }

        // GET: Juegoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juego juego = db.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // POST: Juegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Juego juego = db.Juego.Find(id);
            db.Juego.Remove(juego);
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
