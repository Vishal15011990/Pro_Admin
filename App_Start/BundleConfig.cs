using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Pro_Admin.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/CSS").Include(
             "~/Content/Site.css", 
            "~/Content/bootstrap.min.css",
            "~/Content/font-awesome.min.css",
            "~/Content/font-awesome.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Jquery").Include(
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Scripts/bootstrap.min.js"
               ));


            bundles.Add(new ScriptBundle("~/bundles/JqueryUi").Include(
              "~/Content/Jqgrid/jquery-ui.js"));


            bundles.Add(new ScriptBundle("~/bundles/Jqgrid/js").Include(
             "~/Content/Jqgrid/grid.locale-en.js",
             "~/Content/Jqgrid/jquery-ui.js"));

           bundles.Add(new ScriptBundle("~/Content/Jquerygrid/Css").Include(
                "~/Content/Jqgrid/jquery-ui.css",
                "~/Content/Jqgrid/ui.jqgrid-bootstrap4.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}