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

        PortfolioDetail IPortfolioRepository.GetDetail(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            var illos = GetIllos().Groups;
            var piccies = GetPiccies().Groups;
            var allgroups = piccies.Concat(illos);
            var selectedGroup = allgroups.First(x => x.Images.Any(image => Equals(image.Name, name)));

            return new PortfolioDetail
            {
                Selected = selectedGroup.Images.FirstOrDefault(x => Equals(x.Name, name)),
                Related = selectedGroup.Images.Where(x => !Equals(x.Name, name))
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