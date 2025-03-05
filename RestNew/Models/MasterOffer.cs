using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterOffer : BaseEntity
{
    [DisplayName("OfferId")]
    public int MasterOfferId { get; set; }

    [DisplayName("OfferTitle")]
    public string? MasterOfferTitle { get; set; }

    [DisplayName("OfferBrief")]
    public string? MasterOfferBreef { get; set; }

    [DisplayName("OfferDesc")]
    public string? MasterOfferDesc { get; set; }

    [DisplayName("OfferImageUrl")]
    public string? MasterOfferImageUrl { get; set; }
}
