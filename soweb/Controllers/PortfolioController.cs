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

        public ActionResult Id(string id)
        {
            var portfolio = GetPortfolio();
            var model = new PortfolioDetail();

            model.Selected = portfolio
                .Groups
                .SelectMany(x => x.Images)
                .FirstOrDefault(x => x.Id.Equals(id));

            model.Related = portfolio
                .Groups
                .First(g => g.Images.Any(image => image.Id == id))
                .Images
                .Where(p => p.Id != id)
                .ToArray();

            return View(model);
        }

        private Portfolio GetPortfolio()
        {
            var file = System.IO.Path.Combine(Server.MapPath("~/App_Data/"), "portfolio.json");
            var json = System.IO.File.ReadAllText(file);
            return JsonConvert.DeserializeObject<Portfolio>(json);
        }
    }
}