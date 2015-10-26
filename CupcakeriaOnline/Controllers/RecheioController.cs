using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CupcakeriaOnline.Models;
using CupcakeriaOnline.Repository;

namespace CupcakeriaOnline.Controllers
{
    public class RecheioController : Controller
    {
        private RecheioRepository db = new RecheioRepository();

        //
        // GET: /Recheio/

        public ActionResult Index()
        {
            return View(db.getContext().Recheios.ToList());
        }

        //
        // GET: /Recheio/Details/5

        public ActionResult Details(int id = 0)
        {
            RecheioModel recheiomodel = db.Busca(id);
            if (recheiomodel == null)
            {
                return HttpNotFound();
            }
            return View(recheiomodel);
        }

        //
        // GET: /Recheio/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Recheio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecheioModel recheiomodel)
        {
            if (ModelState.IsValid)
            {
                db.Adiciona(recheiomodel);
                db.Salva();
                return RedirectToAction("Index");
            }

            return View(recheiomodel);
        }

        //
        // GET: /Recheio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RecheioModel recheiomodel = db.Busca(id);
            if (recheiomodel == null)
            {
                return HttpNotFound();
            }
            return View(recheiomodel);
        }

        //
        // POST: /Recheio/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RecheioModel recheiomodel)
        {
            if (ModelState.IsValid)
            {
                db.getContext().Entry(recheiomodel).State = EntityState.Modified;
                db.Salva();
                return RedirectToAction("Index");
            }
            return View(recheiomodel);
        }

        //
        // GET: /Recheio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RecheioModel recheiomodel = db.Busca(id);
            if (recheiomodel == null)
            {
                return HttpNotFound();
            }
            return View(recheiomodel);
        }

        //
        // POST: /Recheio/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecheioModel recheiomodel = db.Busca(id);
            db.Remove(recheiomodel);
            db.Salva();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.getContext().Dispose();
            base.Dispose(disposing);
        }
    }
}