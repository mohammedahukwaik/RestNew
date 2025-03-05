using RestNew.Models;
using System.ComponentModel;

namespace RestNew.ViewModels
{
    public class MasterItemMenuModel : BaseEntity
    {
        public int MasterItemMenuId { get; set; }

        public int MasterCategoryMenuId { get; set; }

        public string? MasterItemMenuTitle { get; set; }

        public string? MasterItemMenuBreef { get; set; }

        public string? MasterItemMenuDesc { get; set; }

        public decimal? MasterItemMenuPrice { get; set; }

        public string? MasterItemMenuImageUrl { get; set; }

        public DateTime? MasterItemMenuDate { get; set; }

        public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }

        public List<MasterCategoryMenu>? ListMasterCategoryMenu { get; set; }
        public IFormFile? ItemMenuFile { get; set; }
    }
}
