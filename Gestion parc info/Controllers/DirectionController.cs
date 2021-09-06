using Gestion_parc_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestion_parc_info.Controllers
{
    public class DirectionController : Controller
    {
        private ApplicationDbContext _context;

        public DirectionController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var direction = _context.Directions.ToList();
            return View(direction);
        }
    }
}