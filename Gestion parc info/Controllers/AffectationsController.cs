using Gestion_parc_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestion_parc_info.Controllers
{
    public class AffectationsController : Controller
    {
        private ApplicationDbContext _context;

        public AffectationsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Liste(int id)
        {
            var affecations = _context.Affectations.Where(c => c.CodeMateriel == id).ToList();
            return View(affecations);
        }
    }
}