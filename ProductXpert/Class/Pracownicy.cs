using System;
using System.Collections.Generic;

namespace ProductXpert;

public partial class Pracownicy
{
    public int Id { get; set; }

    public string? Imie { get; set; }

    public string? Nazwisko { get; set; }

    public string Login { get; set; } = null!;

    public string Haslo { get; set; } = null!;
}
