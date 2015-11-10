using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CupcakeriaOnline.Models;
using CupcakeriaOnline.Repository;
using WebMatrix.WebData;
using CupcakeriaOnline.Filters;
using System.Web.Security;

namespace CupcakeriaOnline.Controllers
{
    //[InitializeSimpleMembership]
    public class PedidoController : Controller
    {
        private CupcakeriaContext db = new CupcakeriaContext();
        public static PedidoModel Pedido;

        //
        // GET: /Pedido/

        public ActionResult Index()
        {
            var pedidos = db.Pedidos.Include(p => p.Cliente);
            return View(pedidos.ToList());
        }

        //
        // GET: /Pedido/Details/5

        public ActionResult Details(int id = 0)
        {
            PedidoModel pedidomodel = db.Pedidos.Find(id);
            if (pedidomodel == null)
            {
                return HttpNotFound();
            }
            return View(pedidomodel);
        }

        //
        // GET: /Pedido/Create

        public ActionResult Create()
        {
            ViewBag.fk_idCliente = new SelectList(db.Cliente, "pk_idCliente", "nomeCliente");
            return View();
        }

        //
        // POST: /Pedido/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoModel pedidomodel)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedidomodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_idCliente = new SelectList(db.Cliente, "pk_idCliente", "nomeCliente", pedidomodel.fk_idCliente);
            return View(pedidomodel);
        }

        //
        // GET: /Pedido/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PedidoModel pedidomodel = db.Pedidos.Find(id);
            if (pedidomodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_idCliente = new SelectList(db.Cliente, "pk_idCliente", "nomeCliente", pedidomodel.fk_idCliente);
            return View(pedidomodel);
        }

        //
        // POST: /Pedido/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PedidoModel pedidomodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_idCliente = new SelectList(db.Cliente, "pk_idCliente", "nomeCliente", pedidomodel.fk_idCliente);
            return View(pedidomodel);
        }

        //
        // GET: /Pedido/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PedidoModel pedidomodel = db.Pedidos.Find(id);
            if (pedidomodel == null)
            {
                return HttpNotFound();
            }
            return View(pedidomodel);
        }

        //
        // POST: /Pedido/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoModel pedidomodel = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedidomodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IniciarPedido(PedidoModel pedido)
        {
            var cliente = db.Cliente.FirstOrDefault(c => c.emailCliente == User.Identity.Name);
            pedido.Cliente = cliente;

            if (ModelState.IsValid)
            {


                Pedido = pedido;
                db.SaveChanges();
                return RedirectToAction("CriarCupcake ", "Cupcake_Pedido");
            }
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}