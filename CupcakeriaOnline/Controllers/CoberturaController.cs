using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CupcakeriaOnline.Models;
using CupcakeriaOnline.Repository;
using System.IO;
using System.Globalization;

namespace CupcakeriaOnline.Controllers
{
    public class CoberturaController : Controller
    {
        private CoberturaRepository db = new CoberturaRepository();

        //
        // GET: /Cobertura/

        [Authorize]
        public ActionResult Index()
        {
            return View(db.getContext().Coberturas.ToList());
        }

        //
        // GET: /Cobertura/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CoberturaModel coberturamodel = db.Busca(id);
            if (coberturamodel == null)
            {
                return HttpNotFound();
            }
            return View(coberturamodel);
        }

        //
        // GET: /Cobertura/Create

        [Authorize]
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
                db.Adiciona(coberturamodel);
                db.Salva();
                return RedirectToAction("Index");
            }

            return View(coberturamodel);
        }

        //
        // GET: /Cobertura/Edit/5

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CoberturaModel coberturamodel = db.Busca(id);
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
                db.getContext().Entry(coberturamodel).State = EntityState.Modified;
                db.Salva();
                return RedirectToAction("Index");
            }
            return View(coberturamodel);
        }

        //
        // GET: /Cobertura/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CoberturaModel coberturamodel = db.Busca(id);
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
            CoberturaModel coberturamodel = db.Busca(id);
            db.getContext().Coberturas.Remove(coberturamodel);
            db.Salva();
            return RedirectToAction("Index");
        }

        public ActionResult UploadDeArquivo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadDeArquivo(HttpPostedFileBase arquivo)
        {
            arquivo = Request.Files["arquivo"];
            string result = new StreamReader(arquivo.InputStream).ReadToEnd();
            if (result.Length>0)
            {

                //string result = new StreamReader(arquivo.InputStream).ReadToEnd();
                List<string> resultadoArquivo = result.Split(';').ToList<string>();
                resultadoArquivo.Reverse();

                CoberturaModel cobertura = new CoberturaModel();

                cobertura.descrCobertura = resultadoArquivo[2];
                cobertura.valorUnitCobertura = Convert.ToDouble(resultadoArquivo[1], CultureInfo.CreateSpecificCulture("pt-BR"));
                cobertura.dispCobertura = Convert.ToBoolean(resultadoArquivo[0]);
                //ViewBag.Cobertura = cobertura;
                TempData["cobertura"] = cobertura;
                return RedirectToAction("CriarDoArquivo");
            }

            return View();
        }

        public ActionResult CriarDoArquivo()
        {
            CoberturaModel cob = (CoberturaModel)TempData["cobertura"];
            ViewBag.descricao = cob.descrCobertura;
            ViewBag.valor = Convert.ToString(cob.valorUnitCobertura, CultureInfo.CreateSpecificCulture("pt-BR"));
            ViewBag.disp = cob.dispCobertura;

            @ViewBag.Message = "Cadastre a Cobertura";
            
            return View();
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarDoArquivo(CoberturaModel cobertura)
        {
            if (ModelState.IsValid)
            {

                db.Adiciona(cobertura);
                db.Salva();
                return RedirectToAction("Index");
            }
            return View(cobertura);
        }

        protected override void Dispose(bool disposing)
        {
            db.getContext().Dispose();
            base.Dispose(disposing);
        }



        /*[HttpPost]
        public ActionResult Upload()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                }
            }

            return RedirectToAction("UploadDocument");*/
        
    }
}
