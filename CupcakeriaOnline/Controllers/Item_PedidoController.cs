using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CupcakeriaOnline.Controllers
{
    public class Item_PedidoController : Controller
    {
        //
        // GET: /Item_Pedido/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Item_Pedido/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Item_Pedido/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Item_Pedido/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Item_Pedido/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Item_Pedido/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Item_Pedido/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Item_Pedido/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
