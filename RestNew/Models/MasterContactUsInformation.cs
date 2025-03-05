using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterContactUsInformation : BaseEntity
{
    [DisplayName("ContactUsId")]
    public int MasterContactUsInformationId { get; set; }

    [DisplayName("ContactUsDesc")]
    public string? MasterContactUsInformationIdesc { get; set; }

    [DisplayName("ContactUsImageUrl")]
    public string? MasterContactUsInformationImageUrl { get; set; }

    [DisplayName("ContactUsRedirect")]
    public string? MasterContactUsInformationRedirect { get; set; }

}
