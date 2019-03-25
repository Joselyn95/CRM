using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SITE_CRM
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/vendor/fontawesome-free/css/all.min.css",
                "~/Content/vendor/datatables/dataTables.bootstrap4.css",
                "~/Content/css/sb-admin.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/vendor/chart.js/Chart.min.js",
                "~/Content/vendor/datatables/jquery.dataTables.js",
                "~/Content/vendor/datatables/dataTables.bootstrap4.js",
                "~/Content/js/sb-admin.min.js",
                "~/Content/js/demo/datatables-demo.js",
                "~/Content/js/demo/chart-area-demo.js"

                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include(
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/jquery.validate*",
                       "~/Scripts/modernizr-*",
                       "~/Scripts/bootstrap.js",
                        "~/Content/bootstrap.css",
                        "~/Content/Site.css"
                       ));
        }
    }
}