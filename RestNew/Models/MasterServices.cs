using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterServices : BaseEntity
{
    [DisplayName("ServicesId")]
    public int MasterServicesId { get; set; }

    [DisplayName("ServicesTitle")]
    public string? MasterServicesTitle { get; set; }

    [DisplayName("ServicesDesc")]
    public string? MasterServicesDesc { get; set; }

    [DisplayName("ServicesImage")]
    public string? MasterServicesImage { get; set; }
}
