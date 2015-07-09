using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Soweb.Models;

namespace Soweb.Controllers
{
    public class PortfolioController : Controller
    {
        public ActionResult Index()
        {
            var model = GetPortfolio();
            return View(model);
        }

        public ActionResult Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var portfolio = GetPortfolio();
            var model = new PortfolioDetail();
            model.Selected = portfolio
                .Groups
                .SelectMany(x => x.Images)
                .FirstOrDefault(x => Equals(x.Id, id));

            if (model.Selected == null)
            {
                return RedirectToAction("Index");
            }

            model.Related = portfolio
                .Groups
                .First(g => g.Images.Any(image => Equals(image.Id, id)))
                .Images
                .Where(p => !Equals(p.Id, id))
                .ToArray();

            return View(model);
        }

        private Portfolio GetPortfolio()
        {
            var path = System.IO.Path.Combine(Server.MapPath("~/App_Data/"), "portfolio.json");
            var rawtext = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Portfolio>(rawtext);
        }

        private bool Equals(string val1, string val2)
        {
            return val1.ToLower().Equals(val2.ToLower());
        }
    }
}