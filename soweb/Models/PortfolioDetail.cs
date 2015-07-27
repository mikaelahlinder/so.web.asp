using System.Collections.Generic;

namespace Soweb.Models
{
    public class PortfolioDetail
    {
        public Image Selected { get; set; }

        public IEnumerable<Image> Related { get; set; }
    }
}