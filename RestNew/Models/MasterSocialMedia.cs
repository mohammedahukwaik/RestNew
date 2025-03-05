using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterSocialMedia : BaseEntity
{
    [DisplayName("SocialMediaId")]
    public int MasterSocialMediaId { get; set; }

    [DisplayName("SocialMediaImageUrl")]
    public string MasterSocialMediaImageUrl { get; set; } = null!;

    [DisplayName("SocialMediaClassName")]
    public string MasterSocialMediaClassName { get; set; } = null!;

    [DisplayName("SocialMediaUrl")]
    public string MasterSocialMediaUrl { get; set; } = null!;
}
