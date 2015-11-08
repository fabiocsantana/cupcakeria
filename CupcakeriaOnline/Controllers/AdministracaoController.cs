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
    public class AdministracaoController : Controller
    {
        private CupcakeriaContext db = new CupcakeriaContext();

        //
        // GET: /Administracao/

        public ActionResult Index()
        {
            return View(db.AdministracaoModels.ToList());
        }

        //
        // GET: /Administracao/Details/5

        public ActionResult Details(int id = 0)
        {
            AdministracaoModel administracaomodel = db.AdministracaoModels.Find(id);
            if (administracaomodel == null)
            {
                return HttpNotFound();
            }
            return View(administracaomodel);
        }

        //
        // GET: /Administracao/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administracao/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdministracaoModel administracaomodel)
        {
            if (ModelState.IsValid)
            {
                db.AdministracaoModels.Add(administracaomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administracaomodel);
        }

        //
        // GET: /Administracao/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AdministracaoModel administracaomodel = db.AdministracaoModels.Find(id);
            if (administracaomodel == null)
            {
                return HttpNotFound();
            }
            return View(administracaomodel);
        }

        //
        // POST: /Administracao/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdministracaoModel administracaomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administracaomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administracaomodel);
        }

        //
        // GET: /Administracao/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AdministracaoModel administracaomodel = db.AdministracaoModels.Find(id);
            if (administracaomodel == null)
            {
                return HttpNotFound();
            }
            return View(administracaomodel);
        }

        //
        // POST: /Administracao/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministracaoModel administracaomodel = db.AdministracaoModels.Find(id);
            db.AdministracaoModels.Remove(administracaomodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}