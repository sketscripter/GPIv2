using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_parc_info.Models;
using Gestion_parc_info.ViewModels;

namespace Gestion_parc_info.Controllers
{
    public class MaterielsController : Controller
    {
        private ApplicationDbContext _context;

        public MaterielsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                var materiels = _context.Materiels.Include("Fournisseur").Include("Utilisateur").Include("ContratMaintenance").Include("Caracteristique").ToList();
                return View(materiels);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
       public ActionResult Detail(int id)
        {
            var materiel = _context.Materiels.Include("Fournisseur").Include("Utilisateur").Include("ContratMaintenance").Include("Caracteristique").Where(c => c.Id == id).FirstOrDefault();
            if (materiel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(materiel);
            }
        }

        [HttpGet]
        public ActionResult New()
        {
            var fournisseurs = _context.Fournisseurs.ToList();
            var utilisateur = _context.Utilisateurs.ToList();
            var contratm = _context.ContratMaintenances.ToList();
            var caract = _context.Caracteristiques.ToList();
            var newMaterielViewModel = new materielViewModel()
            {
                Fournisseurs = fournisseurs,
                Utilisateurs = utilisateur,
                ContratMaintenances = contratm,
                Caracteristiques = caract,
                Materiel = new Materiel()
            };
            return View(newMaterielViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var materielInDb = _context.Materiels.Find(id);

            if (materielInDb == null)
            {
                return HttpNotFound();
            }

            var fournisseurs = _context.Fournisseurs.ToList();
            var utilisateur = _context.Utilisateurs.ToList();
            var contratm = _context.ContratMaintenances.ToList();
            var caract = _context.Caracteristiques.ToList();

            var newMaterielViewModel = new materielViewModel()
            {
                Fournisseurs = fournisseurs,
                Utilisateurs = utilisateur,
                ContratMaintenances = contratm,
                Caracteristiques = caract,
                Materiel = materielInDb
            };

            return View(newMaterielViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Materiel materiel)
        {
            if (materiel.Id == 0)
            {
                if (ModelState.IsValid == false)
                {
                    var fournisseurs = _context.Fournisseurs.ToList();
                    var utilisateur = _context.Utilisateurs.ToList();
                    var contratm = _context.ContratMaintenances.ToList();
                    var caract = _context.Caracteristiques.ToList();
                    var newMaterielViewModel = new materielViewModel()
                    {
                        Fournisseurs = fournisseurs,
                        Utilisateurs = utilisateur,
                        ContratMaintenances = contratm,
                        Caracteristiques = caract,
                        Materiel = materiel
                    };
                    return View("New", newMaterielViewModel);
                }
                _context.Materiels.Add(materiel);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    var fournisseurs = _context.Fournisseurs.ToList();
                    var utilisateur = _context.Utilisateurs.ToList();
                    var contratm = _context.ContratMaintenances.ToList();
                    var caract = _context.Caracteristiques.ToList();
                    var newMaterielViewModel = new materielViewModel()
                    {
                        Fournisseurs = fournisseurs,
                        Utilisateurs = utilisateur,
                        ContratMaintenances = contratm,
                        Caracteristiques = caract,
                        Materiel = materiel
                    };
                    return View("Edit", newMaterielViewModel);
                }

                var MaterielInDb = _context.Materiels.Find(materiel.Id);

                MaterielInDb.Designation = materiel.Designation;
                MaterielInDb.DateService = materiel.DateService;
                MaterielInDb.EtatMateriel = materiel.EtatMateriel;
                MaterielInDb.Maintenance = materiel.Maintenance;
                MaterielInDb.Observations = materiel.Observations;
                MaterielInDb.Type = materiel.Type;
                MaterielInDb.Marque = materiel.Marque;
                MaterielInDb.Modele = materiel.Modele;

                MaterielInDb.FournisseurId = materiel.FournisseurId;
                MaterielInDb.UtilisateurId = materiel.UtilisateurId;
                MaterielInDb.ContratMaintenanceId = materiel.ContratMaintenanceId;
                MaterielInDb.CaracteristiquesId = materiel.CaracteristiquesId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}