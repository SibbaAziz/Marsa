using Marsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marsa.Controllers
{
    [Marsa.Authorization.Authorize]
    public class OffreController : Controller
    {
        private readonly VoursaContext db = new VoursaContext();

        // GET: Offre
        public ActionResult Index()
        {
            db.Annonces.ToList();
            ViewBag.MinPrice = 500000;
            ViewBag.MaxPrice = 1000000;
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
            ViewBag.Area = area;
            ViewBag.MinPrice = 500000;
            ViewBag.MaxPrice = 1000000;
            return View("Index", db.Annonces.Where(a => a.City == area)
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
            }).ToList());

        }

        public ActionResult Search(string search, string category, string region, int minprice, int maxprice )
        {


            var result = db.Annonces.Where(a => a.Title.Contains(search) &&
                                                 a.Region == region &&
                                                 a.Price >= minprice &&
                                                 a.Price <= maxprice);

            if(category != "all")
            {
                result = result.Where(a => a.Category == category);
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
                                        PhoneNumber = a.PhoneNumber
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