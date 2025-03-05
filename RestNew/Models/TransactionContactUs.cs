using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class TransactionContactUs
{
    [DisplayName("ContactUsId")]
    public int TransactionContactUsId { get; set; }

    [DisplayName("ContactUsFullName")]
    public string? TransactionContactUsFullName { get; set; }

    [DisplayName("ContactUsEmail")]
    public string? TransactionContactUsEmail { get; set; }

    [DisplayName("ContactUsSubject")]
    public string? TransactionContactUsSubject { get; set; }

    [DisplayName("ContactUsMessage")]
    public string? TransactionContactUsMessage { get; set; }

    public string? CreateId { get; set; }
    public DateTime? CreateDate { get; set; }
}
