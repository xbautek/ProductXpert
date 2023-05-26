using System;
using System.Collections.Generic;

namespace ProductXpert;

public partial class Klienci
{
    public int IdKlienta { get; set; }

    public string? NazwaFirmy { get; set; }

    public string? NumerTelefonu { get; set; }

    public string? EMail { get; set; }

    public virtual ICollection<Zamowienium> Zamowienia { get; set; } = new List<Zamowienium>();
}
