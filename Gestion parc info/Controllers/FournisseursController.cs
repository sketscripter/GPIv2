using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_parc_info.Models;

namespace Gestion_parc_info.Controllers
{
    public class FournisseursController : Controller
    {
        private ApplicationDbContext _context;

        public FournisseursController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                var fournisseurs = _context.Fournisseurs.ToList();

                return View(fournisseurs);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult Detail(int id)
        {
            var fournisseur = _context.Fournisseurs.Where(c => c.CodeFournisseur == id).FirstOrDefault();
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(fournisseur);
            }
        }

        public ActionResult New()
        {
            var Fournisseur = new Fournisseur();

            return View(Fournisseur);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var fournisseurInDb = _context.Fournisseurs.Find(id);

            if (fournisseurInDb == null)
            {
                return HttpNotFound();
            }



            return View(fournisseurInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Fournisseur fournisseur)
        {
            if (fournisseur.CodeFournisseur == 0)
            {
                if (ModelState.IsValid == false)
                {


                    return View("New", fournisseur);
                }
                _context.Fournisseurs.Add(fournisseur);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    return View("Edit", fournisseur);
                }
                var FournisseurInDb = _context.Fournisseurs.Find(fournisseur.CodeFournisseur);

                FournisseurInDb.NomFournisseur = fournisseur.NomFournisseur;
                FournisseurInDb.Adresse = fournisseur.Adresse;
                FournisseurInDb.Telephone = fournisseur.Telephone;
                FournisseurInDb.Fax = fournisseur.Fax;
                FournisseurInDb.Email = fournisseur.Email;

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
            Fournisseur fournisseur = _context.Fournisseurs.Find(id);
            if (fournisseur == null)
            {
                return HttpNotFound();
            }
            return View(fournisseur);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fournisseur fournisseur = _context.Fournisseurs.Find(id);
            _context.Fournisseurs.Remove(fournisseur);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}