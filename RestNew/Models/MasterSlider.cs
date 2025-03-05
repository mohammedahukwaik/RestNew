using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterSlider : BaseEntity
{
    [DisplayName("SliderId")]
    public int MasterSliderId { get; set; }

    [DisplayName("SliderTitle")]
    public string? MasterSliderTitle { get; set; }

    [DisplayName("SliderBrief")]
    public string? MasterSliderBreef { get; set; }

    [DisplayName("SliderDesc")]
    public string? MasterSliderDesc { get; set; }

    [DisplayName("SliderUrl")]
    public string? MasterSliderUrl { get; set; }
}
