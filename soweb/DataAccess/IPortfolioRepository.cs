using Soweb.Models;

namespace Soweb.DataAccess
{
    public interface IPortfolioRepository
    {
        Portfolio GetPiccies();

        Portfolio GetIllos();

        PortfolioDetail GetDetail(string name);
    }
}