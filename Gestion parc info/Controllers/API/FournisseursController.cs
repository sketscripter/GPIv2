using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gestion_parc_info.Models;

namespace Gestion_parc_info.Controllers.API
{
    public class FournisseursController : ApiController
    {
        private ApplicationDbContext _context;

        public FournisseursController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/fournisseurs
        [HttpGet]
        public IEnumerable<Fournisseur> GetFournisseurs()
        {
            return _context.Fournisseurs.ToList();
        }

        // GET /api/fournisseurs/1
        [HttpGet]
        public Fournisseur GetFournisseur(int id)
        {
            var fournisseur = _context.Fournisseurs.Find(id);
            if (fournisseur == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return fournisseur;
        }

        //POST
        [HttpPost]
        public Fournisseur CreateFournisseur(Fournisseur fournisseur)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Fournisseurs.Add(fournisseur);
            _context.SaveChanges();
            return fournisseur;
        }

        //PUT api/fournisseurs/1
        [HttpPut]
        public void UpdateFournisseur(int id, Fournisseur fournisseur)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var fournisseurinDb = _context.Fournisseurs.Find(id);
            if (fournisseurinDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            fournisseurinDb.NomFournisseur = fournisseur.NomFournisseur;
            fournisseurinDb.Adresse = fournisseur.Adresse;
            fournisseurinDb.Telephone = fournisseur.Telephone;
            fournisseurinDb.Fax = fournisseur.Fax;
            fournisseurinDb.Email = fournisseur.Email;
            _context.SaveChanges();

        }

        //GET /api/fournisseurs/1
        [HttpDelete]
        public void DeleteCustommer(int id)
        {
            var fournisseurinDb = _context.Fournisseurs.Find(id);
            if (fournisseurinDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Fournisseurs.Remove(fournisseurinDb);
            _context.SaveChanges();

        }


    }
}


