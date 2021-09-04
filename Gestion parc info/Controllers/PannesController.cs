using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_parc_info.Models;

namespace Gestion_parc_info.Controllers
{
    public class PannesController : Controller
    {
        private ApplicationDbContext _context;

        public PannesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                var pannes = _context.Pannes.ToList();

                return View(pannes);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult Detail(int id)
        {
            var panne = _context.Pannes.Where(c => c.NBonMateriel == id).FirstOrDefault();
            if (panne == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(panne);
            }
        }

        public ActionResult New()
        {
            var Panne = new Panne();

            return View(Panne);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var panneInDb = _context.Pannes.Find(id);

            if (panneInDb == null)
            {
                return HttpNotFound();
            }



            return View(panneInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Panne panne)
        {
            if (panne.NBonMateriel == 0)
            {
                if (ModelState.IsValid == false)
                {


                    return View("New", panne);
                }
                _context.Pannes.Add(panne);
            }
            else
            {
                if (ModelState.IsValid == false)
                {
                    return View("Edit", panne);
                }
                var PanneInDb = _context.Pannes.Find(panne.NBonMateriel);

                PanneInDb.DateReparation = panne.DateReparation;
                PanneInDb.Intervenant = panne.Intervenant;
                PanneInDb.CodeMateriel = panne.CodeMateriel;
                PanneInDb.ResponsableEmission = panne.ResponsableEmission;
                PanneInDb.ResponsableReception = panne.ResponsableReception;
                PanneInDb.ResponsableControle = panne.ResponsableControle;
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
            Panne panne = _context.Pannes.Find(id);
            if (panne == null)
            {
                return HttpNotFound();
            }
            return View(panne);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Panne panne = _context.Pannes.Find(id);
            _context.Pannes.Remove(panne);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}