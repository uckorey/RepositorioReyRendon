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
    public class DesarrolladorasController : Controller
    {
        private MushroomgamesDBEntities db = new MushroomgamesDBEntities();

        // GET: Desarrolladoras
        public ActionResult Index()
        {
            return View(db.Desarrolladora.ToList());
        }

        // GET: Desarrolladoras/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrolladora desarrolladora = db.Desarrolladora.Find(id);
            if (desarrolladora == null)
            {
                return HttpNotFound();
            }
            return View(desarrolladora);
        }




        public ActionResult IndexDesarrolladora()
        {
            MushroomgamesDBEntities GE = new MushroomgamesDBEntities();
            return View(db.Desarrolladora.ToList());
        }

        [HttpPost]
        public ActionResult Search(string Location)
        {
            MushroomgamesDBEntities GE = new MushroomgamesDBEntities();
            var result = db.Desarrolladora.Where(x => x.nombre_Desarrolladora.StartsWith(Location)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Desarrolladoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Desarrolladoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Desarrolladora,nombre_Desarrolladora,informacion_Desarrolladora,direccion_Desarrolladora,telefono_Desarrolladora,correo_Desarrolladora")] Desarrolladora desarrolladora)
        {
            if (ModelState.IsValid)
            {
                db.Desarrolladora.Add(desarrolladora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(desarrolladora);
        }

        // GET: Desarrolladoras/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrolladora desarrolladora = db.Desarrolladora.Find(id);
            if (desarrolladora == null)
            {
                return HttpNotFound();
            }
            return View(desarrolladora);
        }

        // POST: Desarrolladoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Desarrolladora,nombre_Desarrolladora,informacion_Desarrolladora,direccion_Desarrolladora,telefono_Desarrolladora,correo_Desarrolladora")] Desarrolladora desarrolladora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desarrolladora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desarrolladora);
        }

        // GET: Desarrolladoras/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desarrolladora desarrolladora = db.Desarrolladora.Find(id);
            if (desarrolladora == null)
            {
                return HttpNotFound();
            }
            return View(desarrolladora);
        }

        // POST: Desarrolladoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Desarrolladora desarrolladora = db.Desarrolladora.Find(id);
            db.Desarrolladora.Remove(desarrolladora);
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
