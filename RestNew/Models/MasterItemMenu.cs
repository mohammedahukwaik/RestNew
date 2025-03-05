using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterItemMenu : BaseEntity
{
    [DisplayName("ItemMenuIdId")]
    public int MasterItemMenuId { get; set; }

    [DisplayName("CategoryMenuId")]
    public int MasterCategoryMenuId { get; set; }

    [DisplayName("ItemMenuTitle")]
    public string? MasterItemMenuTitle { get; set; }

    [DisplayName("ItemMenuBrief")]
    public string? MasterItemMenuBreef { get; set; }

    [DisplayName("ItemMenuDesc")]
    public string? MasterItemMenuDesc { get; set; }

    [DisplayName("ItemMenuPrice")]
    public decimal? MasterItemMenuPrice { get; set; }

    [DisplayName("ItemMenuImageUrl")]
    public string? MasterItemMenuImageUrl { get; set; }

    [DisplayName("ItemMenuDate")]
    public DateTime? MasterItemMenuDate { get; set; }

    public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }
}
