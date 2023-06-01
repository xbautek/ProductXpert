using System;
using System.Collections.Generic;

namespace ProductXpert.Class;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
