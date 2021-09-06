using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestion_parc_info.Models;

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
                var materiels = _context.Materiels.ToList();
                return View(materiels);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

    }
}