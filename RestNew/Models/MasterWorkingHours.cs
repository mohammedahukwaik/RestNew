using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class MasterWorkingHours : BaseEntity
{
    [DisplayName("WorkingHoursId")]
    public int MasterWorkingHoursId { get; set; }

    [DisplayName("WorkingDays")]
    public string? MasterWorkingHoursIdName { get; set; }

    [DisplayName("WorkingHours")]
    public string? MasterWorkingHoursIdTimeFormTo { get; set; }
}
