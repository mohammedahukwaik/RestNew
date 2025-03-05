using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterPartner : BaseEntity
{
    [DisplayName("PartnerId")]
    public int MasterPartnerId { get; set; }

    [DisplayName("PartnerName")]
    public string? MasterPartnerName { get; set; }

    [DisplayName("PartnerLogoUrl")]
    public string? MasterPartnerLogoImageUrl { get; set; }

    [DisplayName("PartnerWebsiteUrl")]
    public string? MasterPartnerWebsiteUrl { get; set; }
}
