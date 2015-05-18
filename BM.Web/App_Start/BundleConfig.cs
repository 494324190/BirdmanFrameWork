using System.Web;
using System.Web.Optimization;

namespace BM.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.3.min.js",
                        "~/Scripts/jQuery.md5.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/Base/Submit.js",
                        "~/Scripts/Base/Validate.js",
                        "~/Scripts/Base/MouseRollingData.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/BootStrap/bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/iCheck/icheck.min.js",
                      "~/Scripts/Base/BootStrapUser.js"));

            bundles.Add(new ScriptBundle("~/bundles/message").Include(
                     "~/Scripts/message/messenger.min.js"));
            bundles.Add(new StyleBundle("~/Content/message").Include(
                     "~/Content/message/messenger.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/BootStrap/css/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/Base/BootstrapUser.css",
                      "~/Content/iCheck/all.css",
                      "~/Content/Base/RegCSS.css"));

            bundles.Add(new ScriptBundle("~/bundles/Jcrop").Include(
                        "~/Scripts/Jcrop_js/jquery.Jcrop.min.js"));
            bundles.Add(new StyleBundle("~/Content/Jcrop").Include(
                      "~/Content/Jcrop/jquery.Jcrop.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Date").Include(
                "~/Scripts/datetimepicker/bootstrap-datetimepicker.min.js",
                "~/Scripts/datetimepicker/locales/bootstrap-datetimepicker.zh-CN.js"));
            bundles.Add(new StyleBundle("~/Content/Date").Include(
                "~/Content/datetimepicker/bootstrap-datetimepicker.min.css"));
        }
    }
}
