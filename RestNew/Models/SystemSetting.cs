using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class SystemSetting : BaseEntity
{
    [DisplayName("Id")]
    public int SystemSettingId { get; set; }

    [DisplayName("LogoUrl")]
    public string? SystemSettingLogoImageUrl { get; set; }

    [DisplayName("LogoUrl2")]
    public string? SystemSettingLogoImageUrl2 { get; set; }

    [DisplayName("Copyright")]
    public string? SystemSettingCopyright { get; set; }

    [DisplayName("NoteTitle")]
    public string? SystemSettingWelcomeNoteTitle { get; set; }

    [DisplayName("NoteBrief")]
    public string? SystemSettingWelcomeNoteBreef { get; set; }

    [DisplayName("NoteDesc")]
    public string? SystemSettingWelcomeNoteDesc { get; set; }

    [DisplayName("NoteUrl")]
    public string? SystemSettingWelcomeNoteUrl { get; set; }
    [DisplayName("NoteImageUrl")]
    public string? SystemSettingWelcomeNoteImageUrl { get; set; }

    [DisplayName("MapLocation")]
    public string? SystemSettingMapLocation { get; set; }
    public string? Location { get; set; }
    public string? PhoneOne { get; set; }
    public string? PhoneTwo { get; set; }
    public string? EmailOne { get; set; }
    public string? EmailTwo { get; set; }
}
