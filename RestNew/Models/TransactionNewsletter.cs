using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RestNew.Models;

public partial class TransactionNewsletter
{
    [DisplayName("NewsletterId")]
    public int TransactionNewsletterId { get; set; }

    [DisplayName("NewsletterEmail")]
    public string? TransactionNewsletterEmail { get; set; }

    public string? CreateId { get; set; }
    public DateTime? CreateDate { get; set; }
}
