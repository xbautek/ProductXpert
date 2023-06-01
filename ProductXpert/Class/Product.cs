using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductXpert.Class;

public partial class Product
{
    public int ProductId { get; set; }

    public int MaterialId { get; set; }

    [NotMapped]
    public string MaterialName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Amount { get; set; }

    public int? MinimalAmount { get; set; }

    public virtual Material Material { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
