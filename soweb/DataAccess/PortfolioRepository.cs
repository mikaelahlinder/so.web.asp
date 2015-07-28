using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Soweb.Models;

namespace Soweb.DataAccess
{
    public sealed class PortfolioRepository : IPortfolioRepository
    {
        private readonly string _appDataPath;

        public PortfolioRepository(string appDataPath)
        {
            _appDataPath = appDataPath;
        }

        Portfolio IPortfolioRepository.GetPiccies()
        {
            return GetPiccies();
        }

        Portfolio IPortfolioRepository.GetIllos()
        {
            return GetIllos();
        }

        PortfolioDetail IPortfolioRepository.GetDetail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var illos = GetIllos().Groups;
            var piccies = GetPiccies().Groups;
            var allgroups = piccies.Concat(illos);
            var selectedGroup = allgroups.FirstOrDefault(x => x.Images.Any(image => Equals(image.Id, id)));

            if (selectedGroup == null)
            {
                return null;
            }

            return new PortfolioDetail
            {
                Selected = selectedGroup.Images.FirstOrDefault(x => Equals(x.Id, id)),
                Related = selectedGroup.Images.Where(x => !Equals(x.Id, id))
            };
        }

        private Portfolio GetPiccies()
        {
            return GetPortfolio("photos");
        }

        private Portfolio GetIllos()
        {
            return GetPortfolio("illos");
        }

        private Portfolio GetPortfolio(string filename)
        {
            var path = Path.Combine(_appDataPath, string.Format("{0}.json", filename));
            var rawtext = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Portfolio>(rawtext);
        }

        private bool Equals(string val1, string val2)
        {
            return val1.Equals(val2, StringComparison.OrdinalIgnoreCase);
        }
    }
}