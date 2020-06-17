using Marsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marsa.Controllers
{
    public class OffreController : Controller
    {
        VoursaContext db = new VoursaContext();

        // GET: Offre
        public ActionResult Index()
        {
            db.Annonces.ToList();
            return View(db.Annonces.Select(a => new AnnonceModel()
            {
                Id = a.Id,
                Photos = a.Photos,
                Price = a.Price,
                Title = a.Title,
                City = a.City,
                Pseudo = a.Pseudo,
                Description = a.Description,
                PhoneNumber = a.PhoneNumber
            }).ToList());
           
        }
    }
}