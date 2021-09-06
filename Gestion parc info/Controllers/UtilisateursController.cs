using Gestion_parc_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gestion_parc_info.Controllers
{
    public class UtilisateursController : Controller
    {
        private ApplicationDbContext _context;

        public UtilisateursController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                var utilisateurs = _context.Utilisateurs.ToList();

                return View(utilisateurs);
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
        }
        
        

        public ActionResult Detail(int id)
        {
            var utilisateur = _context.Utilisateurs.Where(c => c.Id == id).FirstOrDefault();
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(utilisateur);
            }
        }

        [HttpGet]
        public ActionResult New()
        {

            var newUtilisateurViewModel = new Utilisateur();
            
            return View(newUtilisateurViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var utilisateurInDb = _context.Utilisateurs.Find(id);

            if (utilisateurInDb == null)
            {
                return HttpNotFound();
            }

            var newUtilisateurViewModel = utilisateurInDb;

            return View(newUtilisateurViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Utilisateur utilisateur)
        {
            if (utilisateur.Id == 0)
            {
                if (ModelState.IsValid == false)
                {
                   
                    
                    return View("New", utilisateur);
                }
                _context.Utilisateurs.Add(utilisateur);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    return View("Edit", utilisateur);
                }

                var UtilisateurInDb = _context.Utilisateurs.Find(utilisateur.Id);

                UtilisateurInDb.Nom = utilisateur.Nom;
                UtilisateurInDb.Prenom = utilisateur.Prenom;
                UtilisateurInDb.MotDePasse = utilisateur.MotDePasse;
                UtilisateurInDb.Role = utilisateur.Role;
                UtilisateurInDb.Structure = utilisateur.Structure;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur util = _context.Utilisateurs.Find(id);
            if (util == null)
            {
                return HttpNotFound();
            }
            return View(util);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateur util = _context.Utilisateurs.Find(id);
            _context.Utilisateurs.Remove(util);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}