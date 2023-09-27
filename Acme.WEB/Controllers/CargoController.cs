using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Acme.WEB;

namespace Acme.WEB.Controllers
{
    public class CargoController : Controller
    {
        private BD_AcmeEntities db = new BD_AcmeEntities();

        // GET: Cargo
        public ActionResult Index()
        {
            return View(db.Cargo.ToList());
        }

        // GET: Cargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // GET: Cargo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargo/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCargo,Nome")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Cargo.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        // GET: Cargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCargo,Nome")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        // GET: Cargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo cargo = db.Cargo.Find(id);
            db.Cargo.Remove(cargo);
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
