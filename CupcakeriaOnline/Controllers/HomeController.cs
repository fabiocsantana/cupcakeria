﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CupcakeriaOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.Identity.Name != "Administrador")
                {
                    return RedirectToAction("Index", "Cliente"); 
                }
                else
                {
                    return RedirectToAction("Index", "Administracao"); 

                }

            }
            else{
                return RedirectToAction("Login", "Cliente");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
