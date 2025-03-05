using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterMenu : BaseEntity
{
    [DisplayName("MenuId")]
    public int? MasterMenuId { get; set; }

    [DisplayName("MenuName")]
    public string MasterMenuName { get; set; } = null!;

    [DisplayName("MenuUrl")]
    public string MasterMenuUrl { get; set; } = null!;
}
