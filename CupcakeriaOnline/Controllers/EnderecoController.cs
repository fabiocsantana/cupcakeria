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
    public class EnderecoController : Controller
    {
        private CupcakeriaContext db = new CupcakeriaContext();

        //
        // GET: /Endereco/

        public ActionResult Index()
        {
            var endereco = db.Endereco.Include(e => e.Cliente);
            return View(endereco.ToList());
        }

        //
        // GET: /Endereco/Details/5

        public ActionResult Details(int id = 0)
        {
            EnderecoModel enderecomodel = db.Endereco.Find(id);
            if (enderecomodel == null)
            {
                return HttpNotFound();
            }
            return View(enderecomodel);
        }

        //
        // GET: /Endereco/Create

        public ActionResult Create()
        {
            ViewBag.fk_idCliente = new SelectList(db.Cliente, "pk_idCliente", "nomeCliente");
            return View();
        }

        //
        // POST: /Endereco/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnderecoModel enderecomodel)
        {
            enderecomodel.Cliente = db.Cliente.FirstOrDefault(c => c.emailCliente == User.Identity.Name);
            if (ModelState.IsValid)
            {
                db.Endereco.Add(enderecomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_idCliente = new SelectList(db.Cliente, "pk_idCliente", "nomeCliente", enderecomodel.fk_idCliente);
            return View(enderecomodel);
        }

        //
        // GET: /Endereco/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EnderecoModel enderecomodel = db.Endereco.Find(id);
            if (enderecomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_idCliente = new SelectList(db.Cliente, "pk_idCliente", "nomeCliente", enderecomodel.fk_idCliente);
            return View(enderecomodel);
        }

        //
        // POST: /Endereco/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EnderecoModel enderecomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enderecomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_idCliente = new SelectList(db.Cliente, "pk_idCliente", "nomeCliente", enderecomodel.fk_idCliente);
            return View(enderecomodel);
        }

        //
        // GET: /Endereco/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EnderecoModel enderecomodel = db.Endereco.Find(id);
            if (enderecomodel == null)
            {
                return HttpNotFound();
            }
            return View(enderecomodel);
        }

        //
        // POST: /Endereco/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnderecoModel enderecomodel = db.Endereco.Find(id);
            db.Endereco.Remove(enderecomodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult MeusEnderecos()
        {
            var listaEndereco = db.Endereco.ToList();

            var meusEnderecos = listaEndereco.Where(end => end.Cliente.emailCliente == User.Identity.Name);

            return View(meusEnderecos.ToList());
        }

        
    }
}