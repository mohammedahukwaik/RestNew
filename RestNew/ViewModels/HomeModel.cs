using RestNew.Models;

namespace RestNew.ViewModels
{
    public class HomeModel
    {
        public List<MasterMenu> ListMasterMenu { get; set; }
        public List<MasterSlider> ListMasterSlider { get; set; }
        public List<MasterServices> ListMasterServices { get; set; }
        public List<MasterPartner> ListMasterPartner { get; set; }
        public MasterOffer MasterOffer { get; set; }
        public SystemSetting SystemSetting { get; set; }
        public List<PeopleOpinion> ListPeopleOpinion { get; set; }
        public List<MasterWorkingHours> ListMasterWorkingHours { get; set; }
        public List<MasterSocialMedia> ListMasterSocialMedia { get; set; }
        public List<MasterCategoryMenu> ListMasterCategoryMenu { get; set; }
        public List<MasterItemMenu> ListMasterItemMenu { get; set; }
        public MasterContactUsInformation MasterContactUsInformation { get; set; }

    }
}
