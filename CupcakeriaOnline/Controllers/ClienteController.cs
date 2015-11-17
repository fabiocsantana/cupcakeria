using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
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

        public ActionResult Index(ClienteModel cliente)
        {
            var sysCliente = db.Cliente.FirstOrDefault(c => c.emailCliente == cliente.emailCliente);
            
            return View(sysCliente);

            //return View(db.Cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            ClienteModel clientemodel = db.Cliente.FirstOrDefault(c => c.emailCliente == User.Identity.Name);
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

        public ActionResult Edit()
        {
            ClienteModel clientemodel = db.Cliente.First(c => c.emailCliente == User.Identity.Name);

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

        //apenas exibe a tela de login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //pega as informacoes que o usuario inseriu para fazer validacao
        [HttpPost]
        public ActionResult Login(Models.ClienteModel cliente)
        {
                VariavelGlobal a = new VariavelGlobal();
                a.Cria();
                if (EhValido(cliente.emailCliente, cliente.loginUsuSenha))
                {
                    FormsAuthentication.SetAuthCookie(cliente.emailCliente, false);
                    return RedirectToAction("Index", "Cliente", cliente);
                }
                else
                {
                    ModelState.AddModelError("", "Não foi possível efetuar o login");
                }

            return View(cliente);
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Models.ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                using (var dbContext = new CupcakeriaContext())
                {
                    var emailExistente = db.Cliente.FirstOrDefault(c => c.emailCliente == cliente.emailCliente);

                    if (emailExistente == null)
                    {
                        var crypto = new SimpleCrypto.PBKDF2();

                        var senhaCripto = crypto.Compute(cliente.loginUsuSenha);

                        var sysCliente = dbContext.Cliente.Create();

                        sysCliente.emailCliente = cliente.emailCliente;
                        sysCliente.loginUsuSenha = senhaCripto;
                        sysCliente.loginUsuSalt = crypto.Salt;
                        sysCliente.nomeCliente = cliente.nomeCliente;
                        sysCliente.telCliente = cliente.telCliente;
                        sysCliente.dataNascCliente = cliente.dataNascCliente;

                        dbContext.Cliente.Add(sysCliente);
                        dbContext.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email já cadastrado");
                    }
                }

            }
            else
            {
                ModelState.AddModelError("", "Não foi possível efetuar o cadastro");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            VariavelGlobal a = new VariavelGlobal();
            a.Limpa();

            return RedirectToAction("Index", "Home");
        }

        private bool EhValido(String email, String senha)
        {
            bool ehValido;

            var crypto = new SimpleCrypto.PBKDF2();

            using (var db = new CupcakeriaContext())
            {
                var cliente = db.Cliente.FirstOrDefault(c => c.emailCliente == email);

                if(cliente != null){
                    var senhaInseridaCripto = crypto.Compute(senha, cliente.loginUsuSalt); 
                    
                    if (cliente.loginUsuSenha == senhaInseridaCripto)
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

        public ActionResult Perfil()
        {
            return View();
        }

        public ActionResult AlteraPerfil()
        {
            return View();
        }
    }
}