﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CupcakeriaOnline.Models;
using CupcakeriaOnline.Repository;
using System.Globalization;

namespace CupcakeriaOnline.Controllers
{
    public class Cupcake_PedidoController : Controller
    {
        private CupcakeriaContext db = new CupcakeriaContext();
        public static List<Cupcake_Pedido> Carrinho = new List<Cupcake_Pedido>();
        private static VariavelGlobal a = new VariavelGlobal();


        //
        // GET: /Cupcake_Pedido/

        public ActionResult Index()
        {
            var cupcake_pedido = db.Cupcake_Pedido.Include(c => c.Massa).Include(c => c.Recheio).Include(c => c.Cobertura);
            return View(cupcake_pedido.ToList());
        }

        //
        // GET: /Cupcake_Pedido/Details/5

        public ActionResult Details(int id = 0)
        {
            Cupcake_Pedido cupcake_pedido = db.Cupcake_Pedido.Find(id);
            if (cupcake_pedido == null)
            {
                return HttpNotFound();
            }
            return View(cupcake_pedido);
        }

        //
        // GET: /Cupcake_Pedido/Create

        public ActionResult Create()
        {
            ViewBag.fk_idMassa = new SelectList(db.Massa, "pk_idMassa", "descrMassa");
            ViewBag.fk_idRecheio = new SelectList(db.Recheios, "pk_idRecheio", "descrRecheio");
            ViewBag.fk_idCobertura = new SelectList(db.Coberturas, "pk_idCobertura", "descrCobertura");
            return View();
        }

        //
        // POST: /Cupcake_Pedido/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cupcake_Pedido cupcake_pedido)
        {
            if (ModelState.IsValid)
            {
                cupcake_pedido.Massa = db.Massa.Find(cupcake_pedido.fk_idMassa);
                cupcake_pedido.Cobertura = db.Coberturas.Find(cupcake_pedido.fk_idCobertura);
                cupcake_pedido.Recheio = db.Recheios.Find(cupcake_pedido.fk_idRecheio);
                
                //Carrinho.Add(cupcake_pedido);
                //db.SaveChanges();
                return RedirectToAction("Carrinho");
            }

            ViewBag.fk_idMassa = new SelectList(db.Massa, "pk_idMassa", "descrMassa", cupcake_pedido.fk_idMassa);
            ViewBag.fk_idRecheio = new SelectList(db.Recheios, "pk_idRecheio", "descrRecheio", cupcake_pedido.fk_idRecheio);
            ViewBag.fk_idCobertura = new SelectList(db.Coberturas, "pk_idCobertura", "descrCobertura", cupcake_pedido.fk_idCobertura);
            return View(cupcake_pedido);
        }

        //
        // GET: /Cupcake_Pedido/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cupcake_Pedido cupcake_pedido = db.Cupcake_Pedido.Find(id);
            if (cupcake_pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_idMassa = new SelectList(db.Massa, "pk_idMassa", "descrMassa", cupcake_pedido.fk_idMassa);
            ViewBag.fk_idRecheio = new SelectList(db.Recheios, "pk_idRecheio", "descrRecheio", cupcake_pedido.fk_idRecheio);
            ViewBag.fk_idCobertura = new SelectList(db.Coberturas, "pk_idCobertura", "descrCobertura", cupcake_pedido.fk_idCobertura);
            return View(cupcake_pedido);
        }

        //
        // POST: /Cupcake_Pedido/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cupcake_Pedido cupcake_pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cupcake_pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_idMassa = new SelectList(db.Massa, "pk_idMassa", "descrMassa", cupcake_pedido.fk_idMassa);
            ViewBag.fk_idRecheio = new SelectList(db.Recheios, "pk_idRecheio", "descrRecheio", cupcake_pedido.fk_idRecheio);
            ViewBag.fk_idCobertura = new SelectList(db.Coberturas, "pk_idCobertura", "descrCobertura", cupcake_pedido.fk_idCobertura);
            return View(cupcake_pedido);
        }

        //
        // GET: /Cupcake_Pedido/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cupcake_Pedido cupcake_pedido = db.Cupcake_Pedido.Find(id);
            if (cupcake_pedido == null)
            {
                return HttpNotFound();
            }
            return View(cupcake_pedido);
        }

        //
        // POST: /Cupcake_Pedido/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cupcake_Pedido cupcake_pedido = db.Cupcake_Pedido.Find(id);
            db.Cupcake_Pedido.Remove(cupcake_pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CriarCupcake(PedidoModel pedido)
        {
            ViewBag.fk_idMassa = new SelectList(db.Massa.Where(a => a.dispMassa.Equals(true)), "pk_idMassa", "descrMassa");
            ViewBag.fk_idRecheio = new SelectList(db.Recheios.Where(a => a.dispRecheio.Equals(true)), "pk_idRecheio", "descrRecheio");
            ViewBag.fk_idCobertura = new SelectList(db.Coberturas.Where(a => a.dispCobertura.Equals(true)), "pk_idCobertura", "descrCobertura");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarCupcake(Cupcake_Pedido cupcake_pedido)
        {
            /*if (ModelState.IsValid)
            {
                db.Cupcake_Pedido.Add(cupcake_pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/
            MassaModel massa = db.Massa.Find(cupcake_pedido.fk_idMassa);
            CoberturaModel cobertura = db.Coberturas.Find(cupcake_pedido.fk_idCobertura);
            RecheioModel recheio = db.Recheios.Find(cupcake_pedido.fk_idRecheio);

            if (ModelState.IsValid)
            {
                cupcake_pedido.Massa = db.Massa.Find(cupcake_pedido.fk_idMassa);
                cupcake_pedido.Cobertura = db.Coberturas.Find(cupcake_pedido.fk_idCobertura);
                cupcake_pedido.Recheio = db.Recheios.Find(cupcake_pedido.fk_idRecheio);
                cupcake_pedido.Pedido = (PedidoModel)TempData["pedido"];
                PedidoModel pedido = (PedidoModel)TempData["pedido"];
                cupcake_pedido.fk_idPedido = pedido.pk_idPedido;
                a.Adiciona(cupcake_pedido);
                //Carrinho.Add(cupcake_pedido);
                return RedirectToAction("Carrinho_Compras", new { id = cupcake_pedido.pk_idCupcake});
            }
            double? valorTotal = massa.valorUnitMassa + cobertura.valorUnitCobertura + recheio.valorUnitRecheio;

            double? valorTotalCupcake = valorTotal * cupcake_pedido.qtdeItem;

            //ViewBag.fk_idMassa = new SelectList(db.Massa, "pk_idMassa", "descrMassa", cupcake_pedido.fk_idMassa);
            //ViewBag.fk_idRecheio = new SelectList(db.Recheios, "pk_idRecheio", "descrRecheio", cupcake_pedido.fk_idRecheio);
            //ViewBag.fk_idCobertura = new SelectList(db.Coberturas, "pk_idCobertura", "descrCobertura", cupcake_pedido.fk_idCobertura);
            ViewBag.Massa = massa;
            ViewBag.Recheio = recheio;
            ViewBag.Cobertura = cobertura;
            ViewBag.valorCupcake = Convert.ToString(valorTotal, CultureInfo.CreateSpecificCulture("pt-BR"));
            ViewBag.qtdeItem = cupcake_pedido.qtdeItem;
            ViewBag.valorTotalCupcake = Convert.ToString(valorTotalCupcake, CultureInfo.CreateSpecificCulture("pt-BR"));
            return View("CriarCupcakeConfirmar");
        }

        public ActionResult Carrinho_Compras(int id)
        {
            //var cupcake_pedido = db.Cupcake_Pedido.Include(c => c.Massa).Include(c => c.Recheio).Include(c => c.Cobertura);

            List<Cupcake_Pedido> cupcakes = a.getCupcakes();


            ViewBag.cupcakes = cupcakes;
            double? total= 0;
            foreach (var item in a.getCupcakes())
            {
                total += item.valorTotalCupcake;
            }
            ViewBag.total = total;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Carrinho_Compras()
        {
            List<Cupcake_Pedido> cupcakes = a.getCupcakes();

            if (a.getCupcakes().Count() > 0 )
            {

                TempData["Cupcakes"] = cupcakes;
                return RedirectToAction("PedidoConfirmar", "Pedido");
            }
            

            return View();
        }

        public ActionResult InsereCupcake()
        {
            

            foreach (var c in a.getCupcakes())
            {
                c.Pedido = (PedidoModel)TempData["pedido"];
                c.fk_idPedido = c.Pedido.pk_idPedido;
                
            
            }
            if (ModelState.IsValid)
            {
                foreach (var c in a.getCupcakes())
                {
                    db.Massa.Attach(c.Massa);
                    db.Recheios.Attach(c.Recheio);
                    db.Coberturas.Attach(c.Cobertura);
                    db.Pedidos.Attach(c.Pedido);
                    db.Cupcake_Pedido.Add(c);
                    db.SaveChanges();
                    db.Entry(c.Massa).State = EntityState.Detached;
                    db.Entry(c.Recheio).State = EntityState.Detached;
                    db.Entry(c.Cobertura).State = EntityState.Detached;
                    db.Entry(c.Pedido).State = EntityState.Detached;
                    
                }
                a.Limpa();
                return RedirectToAction("PedidosCliente", "Pedido");
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