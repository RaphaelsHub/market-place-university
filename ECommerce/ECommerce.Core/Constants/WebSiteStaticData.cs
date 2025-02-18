using System.Configuration;
using System.Web;
using System.Web.Configuration;
using ECommerce.Core.Models.ViewModels; // Import this namespace for WebConfigurationManager

namespace ECommerce.Core.Constants
{
    public static class WebSiteStaticData
    {
        private static string WorkingAddressShop { get; set; } = ConfigurationManager.AppSettings["WorkingAddressShop"];
        private static string WorkingNameShop { get; set; } = ConfigurationManager.AppSettings["WorkingNameShop"];
        private static string ShopDescription { get; set; } = ConfigurationManager.AppSettings["ShopDescription"];
        private static string InfoEmail { get; set; } = ConfigurationManager.AppSettings["InfoEmail"];
        private static string SupportEmail { get; set; } = ConfigurationManager.AppSettings["SupportEmail"];
        private static string WorkingEmail { get; set; } = ConfigurationManager.AppSettings["WorkingEmail"];
        private static uint InfoNumber { get; set; } = uint.Parse(ConfigurationManager.AppSettings["InfoNumber"]);
        private static uint SupportNumber { get; set; } = uint.Parse(ConfigurationManager.AppSettings["SupportNumber"]);
        private static uint WorkingNumber { get; set; } = uint.Parse(ConfigurationManager.AppSettings["WorkingNumber"]);
        private static string InstagramLink { get; set; } = ConfigurationManager.AppSettings["InstagramLink"];
        private static string FacebookLink { get; set; } = ConfigurationManager.AppSettings["FacebookLink"];
        private static string XLink { get; set; } = ConfigurationManager.AppSettings["XLink"];

        public static void SetData(WebSiteDataViewModel model)
        {
            WorkingAddressShop = model.WorkingAddressShop;
            WorkingNameShop = model.WorkingNameShop;
            ShopDescription = model.ShopDescription;
            InfoEmail = model.InfoEmail;
            SupportEmail = model.SupportEmail;
            WorkingEmail = model.WorkingEmail;
            InfoNumber = model.InfoNumber;
            SupportNumber = model.SupportNumber;
            WorkingNumber = model.WorkingNumber;
            InstagramLink = model.InstagramLink;
            FacebookLink = model.FacebookLink;
            XLink = model.XLink;

            Save();
        }

        public static WebSiteDataViewModel GetData(WebSiteDataViewModel model)
        {
            model.WorkingAddressShop = WorkingAddressShop;
            model.WorkingNameShop = WorkingNameShop;
            model.ShopDescription = ShopDescription;
            model.InfoEmail = InfoEmail;
            model.SupportEmail = SupportEmail;
            model.WorkingEmail = WorkingEmail;
            model.InfoNumber = InfoNumber;
            model.SupportNumber = SupportNumber;
            model.WorkingNumber = WorkingNumber;
            model.InstagramLink = InstagramLink;
            model.FacebookLink = FacebookLink;
            model.XLink = XLink;

            return model;
        }

        private static void Save()
        {
            // Get the absolute path of Web.config using MapPath
            string configFilePath = HttpContext.Current.Server.MapPath("~/Web.config");

            // Open the configuration file using WebConfigurationManager
            var config = WebConfigurationManager.OpenWebConfiguration("~");

            // Access appSettings section
            var appSettings = config.AppSettings.Settings;

            // Modify appSettings
            appSettings["WorkingAddressShop"].Value = WorkingAddressShop;
            appSettings["WorkingNameShop"].Value = WorkingNameShop;
            appSettings["ShopDescription"].Value = ShopDescription;
            appSettings["InfoEmail"].Value = InfoEmail;
            appSettings["SupportEmail"].Value = SupportEmail;
            appSettings["WorkingEmail"].Value = WorkingEmail;
            appSettings["InfoNumber"].Value = InfoNumber.ToString();
            appSettings["SupportNumber"].Value = SupportNumber.ToString();
            appSettings["WorkingNumber"].Value = WorkingNumber.ToString();
            appSettings["InstagramLink"].Value = InstagramLink;
            appSettings["FacebookLink"].Value = FacebookLink;
            appSettings["XLink"].Value = XLink;

            // Save the changes
            config.Save(ConfigurationSaveMode.Modified);
            // Refresh the appSettings section
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
