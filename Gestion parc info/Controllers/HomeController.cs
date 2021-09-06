using Gestion_parc_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestion_parc_info.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

   

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Utilisateur objUser)
        {
            if (ModelState.IsValid)
            {
                               
                    var obj = _context.Utilisateurs.Where(a => a.Id.Equals(objUser.Id) && a.MotDePasse.Equals(objUser.MotDePasse)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Nom.ToString()+" "+obj.Prenom.ToString();
                        Session["Role"] = obj.Role.ToString();
                    Session["Structure"] = obj.Structure.ToString();
                    return RedirectToAction("UserDashBoard");
                    }
                
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session["UserID"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }

        

    }
}