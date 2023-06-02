using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductXpert.Class;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int Amount { get; set; }

    public string? OrderStatus { get; set; }

    [NotMapped]
    public string ProductName { get; set; } = null!;

    [NotMapped]
    public string CompanyName { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product CustomerNavigation { get; set; } = null!;
}
