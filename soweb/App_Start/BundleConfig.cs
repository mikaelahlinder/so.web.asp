using System.Web.Optimization;

namespace Soweb
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundles(bundles);
            RegisterScriptBundles(bundles);
            // BundleTable.EnableOptimizations = true;
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            var scriptBundle = new ScriptBundle("~/Assets/Scripts/after");
            scriptBundle.Include(
                "~/Assets/Scripts/Libs/jquery-2.1.3.min.js",
                "~/Assets/Scripts/Libs/bootstrap.min.js",
                "~/Assets/Scripts/Libs/imagesloaded.pkgd.js",
                //"~/Assets/Scripts/Libs/isotope.pkgd.min.js",
                "~/Assets/Scripts/Libs/masonry.pkgd.min.js",
                //"~/Assets/Scripts/Libs/jquery.easing.1.3.js",
                //"~/Assets/Scripts/Libs/smoothscroll.js",
                "~/Assets/Scripts/app.js");
            bundles.Add(scriptBundle);
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            var cssBundle = new StyleBundle("~/Assets/Styles/before");
            cssBundle.Include("~/Assets/Styles/Bootstrap.css");
            cssBundle.Include("~/Assets/Styles/Ionicons.css");
            cssBundle.Include("~/Assets/Styles/Style.css");
            cssBundle.Include("~/Assets/Styles/So.css");
            bundles.Add(cssBundle);
        }
    }
}