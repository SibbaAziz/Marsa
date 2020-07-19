using Marsa.Core.Models;
using Marsa.Localization;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Marsa.Controllers
{
    [Marsa.Authorization.Authorize]
    [OnStart]
    public class AnnonceController : Controller
    {
        VoursaContext db = new VoursaContext();
        // GET: Annonce
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Annonce annonce, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                annonce.Id = Guid.NewGuid().ToString();

                try
                {
                    foreach (var item in file)
                    {
                        if (file != null)
                        {
                            annonce.Photos += item.FileName + "&";
                            string path = Path.Combine(Server.MapPath("~/Photos"), Path.GetFileName(annonce.Id + "_"+ item.FileName));
                            item.SaveAs(path);

                        }
                    }
                    annonce.Date = DateTime.Now;
                    db.Annonces.Add(annonce);
                    db.SaveChanges();
                    return View("Success");
                }
                catch (Exception)
                {

                    
                }

            }
            return View("Error");
        }
    }
}