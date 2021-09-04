using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_parc_info.Models;

namespace Gestion_parc_info.Controllers
{
    public class ContratMaintenancesController : Controller
    {
        private ApplicationDbContext _context;

        public ContratMaintenancesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                var contratmaintenance = _context.ContratMaintenances.ToList();

                return View(contratmaintenance);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult Detail(int id)
        {
            var contratmaintenance = _context.ContratMaintenances.Where(c => c.NumeroContrat == id).FirstOrDefault();
            if (contratmaintenance == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(contratmaintenance);
            }
        }

        public ActionResult New()
        {
            var ContratMaintenance = new ContratMaintenance();
            
            return View(ContratMaintenance);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contratmaintenanceInDb = _context.ContratMaintenances.Find(id);

            if (contratmaintenanceInDb == null)
            {
                return HttpNotFound();
            }

          

            return View(contratmaintenanceInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ContratMaintenance contratmaintenance)
        {
            if (contratmaintenance.NumeroContrat == 0)
            {
                if (ModelState.IsValid == false)
                {
                    

                    return View("New", contratmaintenance);
                }
                _context.ContratMaintenances.Add(contratmaintenance);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    return View("Edit", contratmaintenance);
                }
                var ContratMaintenanceInDb = _context.ContratMaintenances.Find(contratmaintenance.NumeroContrat);

                ContratMaintenanceInDb.Type = contratmaintenance.Type;
                ContratMaintenanceInDb.Societe = contratmaintenance.Societe;
                ContratMaintenanceInDb.Telephone = contratmaintenance.Telephone;
                ContratMaintenanceInDb.Fax = contratmaintenance.Fax;
                ContratMaintenanceInDb.DateContrat = contratmaintenance.DateContrat;
                ContratMaintenanceInDb.Duree = contratmaintenance.Duree;
                ContratMaintenanceInDb.CoutPrestation = contratmaintenance.CoutPrestation;
                ContratMaintenanceInDb.Adresse = contratmaintenance.Adresse;
                ContratMaintenanceInDb.Email = contratmaintenance.Email;

            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratMaintenance contrat = _context.ContratMaintenances.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            return View(contrat);
        }

        // POST: /Movies/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ContratMaintenance contrat = _context.ContratMaintenances.Find(id);
            _context.ContratMaintenances.Remove(contrat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}