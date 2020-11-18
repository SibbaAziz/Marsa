using Marsa.Localization;
using Marsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marsa.Controllers
{
    [Marsa.Authorization.Authorize]
    [OnStart]
    public class OffreController : Controller
    {
        private readonly VoursaContext db = new VoursaContext();

        // GET: Offre
        public ActionResult Index()
        {
            //db.Annonces.ToList();
            ViewBag.MinPrice = 500000;
            ViewBag.MaxPrice = 1000000;
            return View(db.Annonces.Where(a => a.IsValidated).Select(a => new AnnonceModel()
            {
                Id = a.Id,
                Photos = a.Photos,
                Price = a.Price,
                Title = a.Title,
                City = a.City,
                Pseudo = a.Pseudo,
                Description = a.Description,
                PhoneNumber = a.PhoneNumber,
                Date = a.Date
            }).ToList());
           
        }

        public ActionResult Area(string area)
        {
            ViewBag.Area = area;
            ViewBag.MinPrice = 500000;
            ViewBag.MaxPrice = 1000000;
            return View("Index", db.Annonces.Where(a => a.City == area && a.IsValidated)
                                        .Select(a => new AnnonceModel()
            {
                Id = a.Id,
                Photos = a.Photos,
                Price = a.Price,
                Title = a.Title,
                City = a.City,
                Pseudo = a.Pseudo,
                Description = a.Description,
                PhoneNumber = a.PhoneNumber,
                Date = a.Date
            }).ToList());

        }

        public ActionResult Search(string search, string category, string region, int minprice, int maxprice )
        {
            var translateCategory = string.Empty;

            if (Globals.Categories.ContainsKey(category))
            {
                translateCategory = Globals.Categories[category];
            }
            else
            {
                translateCategory = category;
            }

            var result = db.Annonces.Where(a => a.Title.Contains(search) &&
                                                 (a.Region == region || a.City == region ) &&
                                                 a.Price >= minprice &&
                                                 a.Price <= maxprice &&
                                                 a.IsValidated);

            if(translateCategory != "Toutes catégories")
            {
                result = result.Where(a => a.Category == translateCategory);
            }

            var finalresult =  result.Select(a => new AnnonceModel()
                                    {
                                        Id = a.Id,
                                        Photos = a.Photos,
                                        Price = a.Price,
                                        Title = a.Title,
                                        City = a.City,
                                        Pseudo = a.Pseudo,
                                        Description = a.Description,
                                        PhoneNumber = a.PhoneNumber,
                                        Date = a.Date
                                    })
                                    .ToList();
            ViewBag.Search = search;
            ViewBag.Category = category;
            ViewBag.Area = region;
            ViewBag.MinPrice = minprice;
            ViewBag.MaxPrice = maxprice;
            return View("Index", finalresult);
        }
    }
}