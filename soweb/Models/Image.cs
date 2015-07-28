using System.Text.RegularExpressions;

namespace Soweb.Models
{
    public class Image
    {
        public string Id
        {
            get
            {
                var rgx = new Regex("[^a-zA-Z0-9åäöÅÄÖ]");
                return rgx.Replace(Name, "-").ToLower();
            }
        }

        public string Name { get; set; }

        public string Filename { get; set; }

        public string Description { get; set; }

        public string ExtraInfo { get; set; }

        public string Layout { get; set; }
    }
}