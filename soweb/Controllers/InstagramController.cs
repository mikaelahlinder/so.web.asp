using System.Net;
using System.Web.Mvc;

namespace Soweb.Controllers
{
    public class InstagramController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 360)]
        public JsonResult GetImages()
        {
            using (var client = new WebClient())
            {
                string response = client.DownloadString("https://api.instagram.com/v1/users/594949/media/recent/?client_id=5bddcc58ea1c47ea9615969eb8777930");
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
