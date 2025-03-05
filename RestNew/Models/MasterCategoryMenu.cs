using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterCategoryMenu : BaseEntity
{
    [DisplayName("CategoryMenuId")]
    public int MasterCategoryMenuId { get; set; }

    [DisplayName("CategoryMenuName")]
    public string? MasterCategoryMenuName { get; set; }

    //public virtual ICollection<MasterItemMenu> MasterItemMenus { get; set; } = new List<MasterItemMenu>();
}
