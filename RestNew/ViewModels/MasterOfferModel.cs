using RestNew.Models;
using System.ComponentModel;

namespace RestNew.ViewModels
{
    public class MasterOfferModel : BaseEntity
    {
        public int MasterOfferId { get; set; }

        public string? MasterOfferTitle { get; set; }

        public string? MasterOfferBreef { get; set; }

        public string? MasterOfferDesc { get; set; }

        public string? MasterOfferImageUrl { get; set; }
        public IFormFile? OfferFile { get; set; }   
    }
}
