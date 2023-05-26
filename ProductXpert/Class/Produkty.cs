using System;
using System.Collections.Generic;

namespace ProductXpert;

public partial class Produkty
{
    public int IdProduktu { get; set; }

    public string? Nazwa { get; set; }

    public string? Opis { get; set; }

    public decimal? Cena { get; set; }

    public int? Ilosc { get; set; }

    public int? MinimalnaIlosc { get; set; }

    public int? IdMaterialu { get; set; }

    public virtual Materialy? IdMaterialuNavigation { get; set; }

    public virtual ICollection<Zamowienium> Zamowienia { get; set; } = new List<Zamowienium>();
}
