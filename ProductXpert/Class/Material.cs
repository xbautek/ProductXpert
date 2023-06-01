using System;
using System.Collections.Generic;

namespace ProductXpert.Class;

public partial class Material
{
    public int MaterialId { get; set; }

    public string MaterialName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal Weight { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
