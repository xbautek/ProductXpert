using System;
using System.Collections.Generic;

namespace ProductXpert.Class;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int Amount { get; set; }

    public string? OrderStatus { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product CustomerNavigation { get; set; } = null!;
}
