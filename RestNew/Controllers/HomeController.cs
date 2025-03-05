using Microsoft.AspNetCore.Mvc;
using RestNew.Models.Repositories;
using RestNew.Models;
using RestNew.ViewModels;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore;

namespace RestNew.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterWorkingHours> MasterWorkingHours { get; }
        public IRepository<MasterSocialMedia> MasterSocialMedia { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<PeopleOpinion> PeopleOpinion { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterServices> MasterServices { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }

        public HomeController(
            IRepository<MasterMenu> _MasterMenu,
            IRepository<MasterSlider> _MasterSlider,
            IRepository<SystemSetting> _SystemSetting,
            IRepository<MasterWorkingHours> _MasterWorkingHours,
            IRepository<MasterSocialMedia> _MasterSocialMedia,
            IRepository<MasterOffer> _MasterOffer,
            IRepository<PeopleOpinion> _PeopleOpinion,
            IRepository<MasterPartner> _MasterPartner,
            IRepository<MasterServices> _MasterServices,
            IRepository<MasterCategoryMenu> _MasterCategoryMenu,
            IRepository<MasterItemMenu> _MasterItemMenu,
            IRepository<MasterContactUsInformation> _MasterContactUsInformation
            )
        {
            MasterMenu = _MasterMenu;
            MasterSlider = _MasterSlider;
            SystemSetting = _SystemSetting;
            MasterWorkingHours = _MasterWorkingHours;
            MasterSocialMedia = _MasterSocialMedia;
            MasterOffer = _MasterOffer;
            PeopleOpinion = _PeopleOpinion;
            MasterPartner = _MasterPartner;
            MasterServices = _MasterServices;
            MasterCategoryMenu = _MasterCategoryMenu;
            MasterItemMenu = _MasterItemMenu;
            MasterContactUsInformation = _MasterContactUsInformation;
        }
        public IActionResult Index()
        {
            var masterOffer = MasterOffer.ViewClient().FirstOrDefault();
            var systemSetting = SystemSetting.ViewClient().FirstOrDefault();
            var masterContactUsInformation = MasterContactUsInformation.ViewClient().FirstOrDefault();
            var data = new HomeModel
            {
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterSlider = MasterSlider.ViewClient(),
                SystemSetting =  systemSetting!,
                MasterOffer =  masterOffer!,
                ListPeopleOpinion = PeopleOpinion.ViewClient(),
                ListMasterWorkingHours = MasterWorkingHours.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterPartner = MasterPartner.ViewClient(),
                MasterContactUsInformation = masterContactUsInformation!,
                ListMasterItemMenu = MasterItemMenu.ViewClient(),
            };
            return View(data);
        }

        public IActionResult About()
        {
            var systemSetting = SystemSetting.ViewClient().FirstOrDefault();
            var masterContactUsInformation = MasterContactUsInformation.ViewClient().FirstOrDefault();
            var data = new HomeModel
            {
                SystemSetting = systemSetting!,
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterWorkingHours =  MasterWorkingHours.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterServices = MasterServices.ViewClient(),
                MasterContactUsInformation = masterContactUsInformation!,
            };
            return View(data);
        }

        public IActionResult Menu() 
        {
            var systemSetting = SystemSetting.ViewClient().FirstOrDefault();
            var masterContactUsInformation = MasterContactUsInformation.ViewClient().FirstOrDefault();
            var data = new HomeModel 
            {
                SystemSetting = systemSetting!,
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterWorkingHours = MasterWorkingHours.ViewClient(),
                ListMasterPartner = MasterPartner.ViewClient(),
                ListMasterCategoryMenu = MasterCategoryMenu.ViewClient(),
                ListMasterItemMenu = MasterItemMenu.ViewClient(),
                MasterContactUsInformation = masterContactUsInformation!,
            };
            return View(data);
        }

        public IActionResult ContactUs() 
        {
            var systemSetting = SystemSetting.ViewClient().FirstOrDefault();
            var masterContactUsInformation = MasterContactUsInformation.ViewClient().FirstOrDefault();
            var data = new HomeModel 
            {
                SystemSetting = systemSetting!,
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedia.ViewClient(),
                ListMasterWorkingHours = MasterWorkingHours.ViewClient(),
                MasterContactUsInformation = masterContactUsInformation!,
            };
            return View(data);
        }
    }
}
