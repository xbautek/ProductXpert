using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace ProductXpert;

public partial class ProductXpertContext : DbContext
{
    public ProductXpertContext()
    {
    }

    public ProductXpertContext(DbContextOptions<ProductXpertContext> options)
        : base(options)
    {
    }

    public  DbSet<Klienci> Klienci { get; set; }

    public  DbSet<Materialy> Materialy { get; set; }

    public  DbSet<Pracownicy> Pracownicy { get; set; }

    public  DbSet<Produkty> Produkty { get; set; }

    public  DbSet<Zamowienium> Zamowienia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Klienci>(entity =>
        {
            entity.HasKey(e => e.IdKlienta).HasName("PK__klienci__D3E3079EB1A3F878");

            entity.ToTable("klienci");

            entity.Property(e => e.IdKlienta).HasColumnName("ID_klienta");
            entity.Property(e => e.EMail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("E_mail");
            entity.Property(e => e.NazwaFirmy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nazwa_Firmy");
            entity.Property(e => e.NumerTelefonu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Numer_telefonu");
        });

        modelBuilder.Entity<Materialy>(entity =>
        {
            entity.HasKey(e => e.IdMaterialu).HasName("PK__material__8E33B209B9DB1D51");

            entity.ToTable("materialy");

            entity.Property(e => e.IdMaterialu).HasColumnName("ID_materialu");
            entity.Property(e => e.Cena).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Opis)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Waga).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Pracownicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pracowni__3214EC27774F69AD");

            entity.ToTable("Pracownicy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Haslo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("haslo");
            entity.Property(e => e.Imie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imie");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwisko");
        });

        modelBuilder.Entity<Produkty>(entity =>
        {
            entity.HasKey(e => e.IdProduktu).HasName("PK__produkty__879B87B50665C832");

            entity.ToTable("produkty");

            entity.Property(e => e.IdProduktu).HasColumnName("ID_produktu");
            entity.Property(e => e.Cena).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.IdMaterialu).HasColumnName("ID_materialu");
            entity.Property(e => e.MinimalnaIlosc).HasColumnName("Minimalna_ilosc");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Opis)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMaterialuNavigation).WithMany(p => p.Produkties)
                .HasForeignKey(d => d.IdMaterialu)
                .HasConstraintName("FK__produkty__ID_mat__04E4BC85");
        });

        modelBuilder.Entity<Zamowienium>(entity =>
        {
            entity.HasKey(e => e.IdZamowienia).HasName("PK__zamowien__7BF8C9E35B200EC8");

            entity.ToTable("zamowienia");

            entity.Property(e => e.IdZamowienia).HasColumnName("ID_zamowienia");
            entity.Property(e => e.DataZamowienia)
                .HasColumnType("date")
                .HasColumnName("Data_zamowienia");
            entity.Property(e => e.IdKlienta).HasColumnName("ID_klienta");
            entity.Property(e => e.IdProduktu).HasColumnName("ID_produktu");
            entity.Property(e => e.StatusZamowienia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Status_zamowienia");

            entity.HasOne(d => d.IdKlientaNavigation).WithMany(p => p.Zamowienia)
                .HasForeignKey(d => d.IdKlienta)
                .HasConstraintName("FK__zamowieni__ID_kl__0E6E26BF");

            entity.HasOne(d => d.IdProduktuNavigation).WithMany(p => p.Zamowienia)
                .HasForeignKey(d => d.IdProduktu)
                .HasConstraintName("FK__zamowieni__ID_pr__0D7A0286");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProductXpertContext>
{
    public ProductXpertContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductXpertContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductXpert;Integrated Security=True");

        return new ProductXpertContext(optionsBuilder.Options);
    }
}
