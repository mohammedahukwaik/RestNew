using RestNew.Models;
using System.ComponentModel;

namespace RestNew.ViewModels
{
    public class MasterContactUsInformationModel : BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }

        public string? MasterContactUsInformationIdesc { get; set; }

        public string? MasterContactUsInformationImageUrl { get; set; }

        public string? MasterContactUsInformationRedirect { get; set; }

        public IFormFile? ContactUsFile { get; set; }
    }
}
