﻿using System;
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
    public class ClienteController : Controller
    {
        private CupcakeriaContext db = new CupcakeriaContext();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            ClienteModel clientemodel = db.Cliente.Find(id);
            if (clientemodel == null)
            {
                return HttpNotFound();
            }
            return View(clientemodel);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModel clientemodel)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(clientemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientemodel);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClienteModel clientemodel = db.Cliente.Find(id);
            if (clientemodel == null)
            {
                return HttpNotFound();
            }
            return View(clientemodel);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteModel clientemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientemodel);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClienteModel clientemodel = db.Cliente.Find(id);
            if (clientemodel == null)
            {
                return HttpNotFound();
            }
            return View(clientemodel);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteModel clientemodel = db.Cliente.Find(id);
            db.Cliente.Remove(clientemodel);
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