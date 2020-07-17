using Marsa.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Marsa.Controllers
{
    [Marsa.Authorization.Authorize]
    public class DetailsController : Controller
    {
        // GET: Details

        public ActionResult Index(string annonce)
        {
            AnnonceModel annonceModel = new AnnonceModel();
            annonceModel = JsonConvert.DeserializeObject<AnnonceModel>(annonce);
            return View(annonceModel);
        }
    }
}