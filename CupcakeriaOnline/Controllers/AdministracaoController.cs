using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        [HttpGet]
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
                    using (var dbContext = new CupcakeriaContext())
                    {
                        var crypto = new SimpleCrypto.PBKDF2();

                        var senhaCripto = crypto.Compute(administracaomodel.loginAdmSenha);

                        var sysAdm = dbContext.AdministracaoModels.Create();

                        sysAdm.loginAdmSenha = senhaCripto;
                        sysAdm.loginAdmSalt = crypto.Salt;

                        dbContext.AdministracaoModels.Add(sysAdm);
                        dbContext.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }
                }
            else
            {
                ModelState.AddModelError("", "Não foi possível efetuar o cadastro");
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

        //apenas exibe a tela de login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //pega as informacoes que o usuario inseriu para fazer validacao
        [HttpPost]
        public ActionResult Login(Models.AdministracaoModel adm)
        {
            if (EhValido(adm.loginAdmSenha))
            {
                FormsAuthentication.SetAuthCookie("Administrador", false);
                return RedirectToAction("Index", "Administracao", adm);
            }
            else
            {
                ModelState.AddModelError("", "Não foi possível efetuar o login");
            }

            return View(adm);
        }

        private bool EhValido(String senha)
        {
            bool ehValido;

            var crypto = new SimpleCrypto.PBKDF2();

            using (var db = new CupcakeriaContext())
            {
                var sysAdm = db.AdministracaoModels.First(s => s.loginAdmSalt != null);

                var senhaInseridaCripto = crypto.Compute(senha, sysAdm.loginAdmSalt);
                    
                if (sysAdm != null)
                {
                    if (sysAdm.loginAdmSenha == senhaInseridaCripto)
                    {
                        ehValido = true;
                    }
                    else
                    {
                        ehValido = false;
                    }
                }
                else
                {
                    ehValido = false;
                }
            }
            return ehValido;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}