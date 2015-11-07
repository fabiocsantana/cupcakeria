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
    public class MassaController : Controller
    {
        private CupcakeriaContext db = new CupcakeriaContext();

        //
        // GET: /Massa/

        public ActionResult Index()
        {
            return View(db.Massa.ToList());
        }

        //
        // GET: /Massa/Details/5

        public ActionResult Details(int id = 0)
        {
            MassaModel massamodel = db.Massa.Find(id);
            if (massamodel == null)
            {
                return HttpNotFound();
            }
            return View(massamodel);
        }

        //
        // GET: /Massa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Massa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MassaModel massamodel)
        {
            if (ModelState.IsValid)
            {
                db.Massa.Add(massamodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(massamodel);
        }

        //
        // GET: /Massa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MassaModel massamodel = db.Massa.Find(id);
            if (massamodel == null)
            {
                return HttpNotFound();
            }
            return View(massamodel);
        }

        //
        // POST: /Massa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MassaModel massamodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(massamodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(massamodel);
        }

        //
        // GET: /Massa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MassaModel massamodel = db.Massa.Find(id);
            if (massamodel == null)
            {
                return HttpNotFound();
            }
            return View(massamodel);
        }

        //
        // POST: /Massa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MassaModel massamodel = db.Massa.Find(id);
            db.Massa.Remove(massamodel);
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