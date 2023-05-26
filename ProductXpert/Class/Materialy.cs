using System;
using System.Collections.Generic;

namespace ProductXpert;

public partial class Materialy
{
    public int IdMaterialu { get; set; }

    public string? Nazwa { get; set; }

    public string? Opis { get; set; }

    public decimal? Cena { get; set; }

    public decimal? Waga { get; set; }

    public virtual ICollection<Produkty> Produkties { get; set; } = new List<Produkty>();
}
