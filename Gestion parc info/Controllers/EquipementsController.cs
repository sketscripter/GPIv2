using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion_parc_info.Models;
using Gestion_parc_info.ViewModels;

namespace Gestion_parc_info.Controllers
{
       public class EquipementsController : Controller
        {
            private ApplicationDbContext _context;

            public EquipementsController()
            {
                _context = new ApplicationDbContext();
            }

            public ActionResult Index()
            {
                var equipements = _context.Equipements.Include("Direction").ToList();
                return View(equipements);
            }

            public ActionResult Detail(int id)
            {
                var equipement = _context.Equipements.Include("Direction").Where(c => c.Id == id).FirstOrDefault();
                if (equipement == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(equipement);
                }
            }

            [HttpGet]
            public ActionResult New()
            {
                var directions = _context.Directions.ToList();
                var newEquipementViewModel = new equipementViewModel()
                {
                    Directions = directions,
                    Equipement = new Equipement()
                };
                return View(newEquipementViewModel);
            }

            [HttpGet]
            public ActionResult Edit(int id)
            {
                var equipementInDb = _context.Equipements.Find(id);

                if (equipementInDb == null)
                {
                    return HttpNotFound();
                }

                var directions = _context.Directions.ToList();

                var newEquipementViewModel = new equipementViewModel()
                {
                    Directions = directions,
                    Equipement = equipementInDb
                };

                return View(newEquipementViewModel);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Save(Equipement equipement)
            {
                if (equipement.Id == 0)
                {
                    if (ModelState.IsValid == false)
                    {
                        var directions = _context.Directions.ToList();
                        var newEquipementViewModel = new equipementViewModel()
                        {
                            Directions = directions,
                            Equipement = equipement
                        };
                        return View("New", newEquipementViewModel);
                    }
                    _context.Equipements.Add(equipement);
                }
                else
                {
                    if (ModelState.IsValid == false)
                    {
                        var directions = _context.Directions.ToList();
                        var newEquipementViewModel = new equipementViewModel()
                        {
                            Directions = directions,
                            Equipement = equipement
                        };
                        return View("Edit", newEquipementViewModel);
                    }

                    var EquipementInDb = _context.Equipements.Find(equipement.Id);

                    EquipementInDb.Name = equipement.Name;
                EquipementInDb.Quantité = equipement.Quantité;

                EquipementInDb.DirectionId = equipement.DirectionId;
                    
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
