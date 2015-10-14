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
    public class CoberturaController : Controller
    {
        private CupcakeriaContext db = new CupcakeriaContext();

        //
        // GET: /Cobertura/

        public ActionResult Index()
        {
            return View(db.Coberturas.ToList());
        }

        //
        // GET: /Cobertura/Details/5

        public ActionResult Details(int id = 0)
        {
            CoberturaModel coberturamodel = db.Coberturas.Find(id);
            if (coberturamodel == null)
            {
                return HttpNotFound();
            }
            return View(coberturamodel);
        }

        //
        // GET: /Cobertura/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cobertura/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoberturaModel coberturamodel)
        {
            if (ModelState.IsValid)
            {
                db.Coberturas.Add(coberturamodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coberturamodel);
        }

        //
        // GET: /Cobertura/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CoberturaModel coberturamodel = db.Coberturas.Find(id);
            if (coberturamodel == null)
            {
                return HttpNotFound();
            }
            return View(coberturamodel);
        }

        //
        // POST: /Cobertura/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CoberturaModel coberturamodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coberturamodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coberturamodel);
        }

        //
        // GET: /Cobertura/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CoberturaModel coberturamodel = db.Coberturas.Find(id);
            if (coberturamodel == null)
            {
                return HttpNotFound();
            }
            return View(coberturamodel);
        }

        //
        // POST: /Cobertura/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoberturaModel coberturamodel = db.Coberturas.Find(id);
            db.Coberturas.Remove(coberturamodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}