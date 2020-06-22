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

        public ActionResult Area(string area)
        {
            return View("Index", db.Annonces.Where(a => a.City == area).Select(a => new AnnonceModel()
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

        public ActionResult Search(string search, string category, string region)
        {
            var result = db.Annonces.Where(a => a.Title.Contains(search) &&
                                                a.Category == category &&
                                                a.Region == region)
                                    .Select(a => new AnnonceModel()
                                    {
                                        Id = a.Id,
                                        Photos = a.Photos,
                                        Price = a.Price,
                                        Title = a.Title,
                                        City = a.City,
                                        Pseudo = a.Pseudo,
                                        Description = a.Description,
                                        PhoneNumber = a.PhoneNumber
                                    })
                                    .ToList();
            return View("Index", result);
        }
    }
}