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
using System.Globalization;

namespace CupcakeriaOnline.Controllers
{
    //[InitializeSimpleMembership]
    public class PedidoController : Controller
    {
        private CupcakeriaContext db = new CupcakeriaContext();
        public static PedidoModel Pedido;
        public static VariavelGlobal a = new VariavelGlobal();
        

        //
        // GET: /Pedido/

        public ActionResult Index()
        {
            var pedidos = db.Pedidos.Include(p => p.Cliente);
            return View(pedidos.ToList());
        }
        [Authorize]
        public ActionResult PedidosCliente()
        {
            var cliente = db.Cliente.FirstOrDefault(c => c.emailCliente == User.Identity.Name);
            var pedidos = db.Pedidos.Where(p => p.fk_idCliente == cliente.pk_idCliente);
            bool pedidoAberto = false;
            if (a.getCupcakes() != null) { 
                if (a.getCupcakes().Count > 0 )
                {
                    pedidoAberto = true;
            }
            }

            ViewBag.AndamentoPedido = pedidoAberto;

            //Cupcake_PedidoController a = new Cupcake_PedidoController();


            //pedidos = pedidos.Reverse();
            return View(pedidos.ToList());
        }

        public ActionResult Detalhes(int id = 0)
        {
            PedidoModel pedidomodel = db.Pedidos.Find(id);
            if (pedidomodel == null)
            {
                return HttpNotFound();
            }

            var Cupcakes = from n in db.Cupcake_Pedido
                           where n.fk_idPedido == pedidomodel.pk_idPedido 
                           select n;
            var Cliente = db.Cliente.Find(pedidomodel.fk_idCliente);
            var endereco = db.Endereco.Find(pedidomodel.fk_idEndereco);
            // List<Cupcake_Pedido> cupcakess = new List<Cupcake_Pedido>();
            foreach (var c in Cupcakes)
            {
                Cupcake_Pedido ca = c;
                Console.WriteLine("teste");
            } 
         

            ViewBag.Cupcakes = Cupcakes;
            int i = Cupcakes.Count();
            ViewBag.Endereco = endereco;
            ViewBag.Cliente = Cliente;
            return View(pedidomodel);
        }

        public ActionResult PedidosAbertos()
        {
            var pedidos = db.Pedidos.Where(p => p.statusPedido == false);
            return View(pedidos.ToList());
        }

        public ActionResult AlterarStatus(int id = 0)
        {
            PedidoModel pedidomodel = db.Pedidos.Find(id);
            if (pedidomodel == null)
            {
                return HttpNotFound();
            }

            if (pedidomodel.statusPedido.Equals(false))
            {
                pedidomodel.statusPedido = true;
            }
            else {
                pedidomodel.statusPedido = false;
            }
            if (ModelState.IsValid)
            {
                db.Entry(pedidomodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

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

        [Authorize]
        public ActionResult IniciarPedido(PedidoModel pedido)
        {
            var cliente = db.Cliente.FirstOrDefault(c => c.emailCliente == User.Identity.Name);
            pedido.Cliente = cliente;
            pedido.fk_idCliente = cliente.pk_idCliente;

            if (ModelState.IsValid)
            {


                Pedido = pedido;
                //db.SaveChanges();
                TempData["pedido"] = pedido;
                return RedirectToAction("CriarCupcake", "Cupcake_Pedido");
            }
            return View();
        }

        public ActionResult PedidoConfirmar()
        {
            
            List<Cupcake_Pedido> Cupcakes = (List<Cupcake_Pedido>)TempData["Cupcakes"];
            PedidoModel pedidoAFechar = Cupcakes.First().Pedido;
            var cliente = db.Cliente.FirstOrDefault(c => c.emailCliente == User.Identity.Name);
            ViewBag.fk_idEndereco = new SelectList(db.Endereco.Where(c => c.fk_idCliente.Equals(cliente.pk_idCliente)), "pk_idEndereco", "logrEndereco", pedidoAFechar.fk_idEndereco);
            ViewBag.CupcakesDoPedido = Cupcakes;
            double? total = 0;
            foreach (var item in Cupcakes)
            {
                total += item.valorTotalCupcake;
            }
            
            ViewBag.total = Convert.ToString(total, CultureInfo.CreateSpecificCulture("pt-BR")); ;
            TempData["Cupcakes"] = Cupcakes;
            return View(pedidoAFechar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PedidoConfirmar(PedidoModel pedido)
        {
            //List<Cupcake_Pedido> Cupcakes = (List<Cupcake_Pedido>)TempData["Cupcakes"];
           // var cliente = db.Cliente.FirstOrDefault(c => c.emailCliente == User.Identity.Name);
            //pedido.Cliente = cliente;
            //pedido.Endereco = db.Endereco.Find(pedido.fk_idEndereco);
            PedidoModel pedidoTeste = pedido;
            
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                TempData["Pedido"] = pedido;                
                return RedirectToAction("InsereCupcake", "Cupcake_Pedido");
            
            }

            
            return View("Index");
        }
    

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}