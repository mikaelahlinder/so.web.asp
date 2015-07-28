using System.Web.Mvc;
using System.Web.Routing;

using Soweb.DataAccess;

namespace Soweb.Controllers
{
    public class PortfolioController : Controller
    {
        private IPortfolioRepository _portfolioRepository;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _portfolioRepository = new PortfolioRepository(Server.MapPath("~/App_Data/"));
        }

        public ActionResult Index()
        {
            return Piccies();
        }

        public ActionResult Piccies()
        {
            var piccies = _portfolioRepository.GetPiccies();
            return View("Index", piccies);
        }

        public ActionResult Illos()
        {
            var illos = _portfolioRepository.GetIllos();
            return View("Index", illos);
        }

        public ActionResult Detail(string id)
        {
            var detail = _portfolioRepository.GetDetail(id);

            if (detail == null || detail.Selected == null)
            {
                return RedirectToAction("Index");
            }

            return View(detail);
        }
    }
}