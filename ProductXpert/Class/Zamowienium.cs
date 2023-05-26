using System;
using System.Collections.Generic;

namespace ProductXpert;

public partial class Zamowienium
{
    public int IdZamowienia { get; set; }

    public int? IdProduktu { get; set; }

    public int? IdKlienta { get; set; }

    public int? Ilosc { get; set; }

    public DateTime? DataZamowienia { get; set; }

    public string? StatusZamowienia { get; set; }

    public virtual Klienci? IdKlientaNavigation { get; set; }

    public virtual Produkty? IdProduktuNavigation { get; set; }
}
