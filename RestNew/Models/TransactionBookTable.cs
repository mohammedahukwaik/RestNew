using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class TransactionBookTable
{
    [DisplayName("BookTableId")]
    public int TransactionBookTableId { get; set; }

    [DisplayName("BookTableFullName")]
    public string? TransactionBookTableFullName { get; set; }

    [DisplayName("BookTableEmail")]
    public string? TransactionBookTableEmail { get; set; }

    [DisplayName("BookTableMobileNumber")]
    public string? TransactionBookTableMobileNumber { get; set; }

    [DisplayName("BookTableDate")]
    public DateTime? TransactionBookTableDate { get; set; }

    public string? CreateId { get; set; }
    public DateTime? CreateDate { get; set; }
}
