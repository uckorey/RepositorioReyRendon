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
    public class VentasController : Controller
    {
        private MushroomgamesDBEntities db = new MushroomgamesDBEntities();

        // GET: Ventas
        public ActionResult Index()
        {
            var venta = db.Venta.Include(v => v.Descuentos).Include(v => v.Juego).Include(v => v.Usuario);
            return View(venta.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.id_Descuento = new SelectList(db.Descuentos, "id_Descuento", "nombre_Descuento");
            ViewBag.id_Juego = new SelectList(db.Juego, "id_Juego", "nombre_Juego");
            ViewBag.id_Usuario = new SelectList(db.Usuario, "id_Usuario", "nombre_Usuario");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "folio_Venta,id_Juego,id_Usuario,id_Descuento,precioJuego_Venta,fecha_Venta")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Descuento = new SelectList(db.Descuentos, "id_Descuento", "nombre_Descuento", venta.id_Descuento);
            ViewBag.id_Juego = new SelectList(db.Juego, "id_Juego", "nombre_Juego", venta.id_Juego);
            ViewBag.id_Usuario = new SelectList(db.Usuario, "id_Usuario", "nombre_Usuario", venta.id_Usuario);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Descuento = new SelectList(db.Descuentos, "id_Descuento", "nombre_Descuento", venta.id_Descuento);
            ViewBag.id_Juego = new SelectList(db.Juego, "id_Juego", "nombre_Juego", venta.id_Juego);
            ViewBag.id_Usuario = new SelectList(db.Usuario, "id_Usuario", "nombre_Usuario", venta.id_Usuario);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "folio_Venta,id_Juego,id_Usuario,id_Descuento,precioJuego_Venta,fecha_Venta")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Descuento = new SelectList(db.Descuentos, "id_Descuento", "nombre_Descuento", venta.id_Descuento);
            ViewBag.id_Juego = new SelectList(db.Juego, "id_Juego", "nombre_Juego", venta.id_Juego);
            ViewBag.id_Usuario = new SelectList(db.Usuario, "id_Usuario", "nombre_Usuario", venta.id_Usuario);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Venta venta = db.Venta.Find(id);
            db.Venta.Remove(venta);
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
