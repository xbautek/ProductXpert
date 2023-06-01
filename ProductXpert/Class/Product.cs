using System;
using System.Collections.Generic;

namespace ProductXpert.Class;

public partial class Product
{
    public int ProductId { get; set; }

    public int MaterialId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Amount { get; set; }

    public int? MinimalAmount { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
