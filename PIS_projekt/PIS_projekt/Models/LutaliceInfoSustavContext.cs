using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PIS_projekt.Models
{
    public partial class LutaliceInfoSustavContext : DbContext
    {
        /*public LutaliceInfoSustavContext()
        {
        }*/

        public LutaliceInfoSustavContext(DbContextOptions<LutaliceInfoSustavContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grad> Grads { get; set; }
        public virtual DbSet<IzgubljeneZivotinje> IzgubljeneZivotinjes { get; set; }
        public virtual DbSet<Kastrat> Kastrats { get; set; }
        public virtual DbSet<Pasmina> Pasminas { get; set; }
        public virtual DbSet<Skloniste> Sklonistes { get; set; }
        public virtual DbSet<Spol> Spols { get; set; }
        public virtual DbSet<Udomljavanje> Udomljavanjes { get; set; }
        public virtual DbSet<UoceneLutalice> UoceneLutalices { get; set; }
        public virtual DbSet<VrstaZivotinje> VrstaZivotinjes { get; set; }
        public virtual DbSet<ZivotinjaUSklonistu> ZivotinjaUSklonistus { get; set; }
        public virtual DbSet<Zupanija> Zupanijas { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-E0MM447;Initial Catalog=LutaliceInfoSustav;Trusted_Connection=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("Grad");

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.NazivGrada)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Naziv_grada");

                entity.Property(e => e.ZupanijaId).HasColumnName("zupanija_id");

                entity.HasOne(d => d.Zupanija)
                    .WithMany(p => p.Grads)
                    .HasForeignKey(d => d.ZupanijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grad_Zupanija");
            });

            modelBuilder.Entity<IzgubljeneZivotinje>(entity =>
            {
                entity.ToTable("Izgubljene_zivotinje");

                entity.Property(e => e.IzgubljeneZivotinjeId)
                    .ValueGeneratedNever()
                    .HasColumnName("izgubljene_zivotinje_id");

                entity.Property(e => e.BrojMikrocipa)
                    .HasMaxLength(50)
                    .HasColumnName("broj_mikrocipa");

                entity.Property(e => e.DatumNestanka)
                    .HasColumnType("date")
                    .HasColumnName("Datum_nestanka");

                entity.Property(e => e.DatumPrijave)
                    .HasColumnType("date")
                    .HasColumnName("Datum_prijave");

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.Ime).HasMaxLength(50);

                entity.Property(e => e.KastratId).HasColumnName("kastrat_id");

                entity.Property(e => e.Kontakt).HasMaxLength(50);

                entity.Property(e => e.LokacijaNestanka)
                    .HasMaxLength(50)
                    .HasColumnName("Lokacija_nestanka");

                entity.Property(e => e.PasminaId).HasColumnName("pasmina_id");

                entity.Property(e => e.Slika).HasMaxLength(50);

                entity.Property(e => e.SpolId).HasColumnName("spol_id");

                entity.Property(e => e.VrstaZivotinjeId).HasColumnName("vrsta_zivotinje_id");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.IzgubljeneZivotinjes)
                    .HasForeignKey(d => d.GradId)
                    .HasConstraintName("FK_Izgubljene_zivotinje_Grad");

                entity.HasOne(d => d.Kastrat)
                    .WithMany(p => p.IzgubljeneZivotinjes)
                    .HasForeignKey(d => d.KastratId)
                    .HasConstraintName("FK_Izgubljene_zivotinje_Kastrat");

                entity.HasOne(d => d.Pasmina)
                    .WithMany(p => p.IzgubljeneZivotinjes)
                    .HasForeignKey(d => d.PasminaId)
                    .HasConstraintName("FK_Izgubljene_zivotinje_Pasmina");

                entity.HasOne(d => d.Spol)
                    .WithMany(p => p.IzgubljeneZivotinjes)
                    .HasForeignKey(d => d.SpolId)
                    .HasConstraintName("FK_Izgubljene_zivotinje_Spol");

                entity.HasOne(d => d.VrstaZivotinje)
                    .WithMany(p => p.IzgubljeneZivotinjes)
                    .HasForeignKey(d => d.VrstaZivotinjeId)
                    .HasConstraintName("FK_Izgubljene_zivotinje_Vrsta_zivotinje");
            });

            modelBuilder.Entity<Kastrat>(entity =>
            {
                entity.ToTable("Kastrat");

                entity.Property(e => e.KastratId).HasColumnName("kastrat_id");

                entity.Property(e => e.JeLiKastrat)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("je_li_kastrat");
            });

            modelBuilder.Entity<Pasmina>(entity =>
            {
                entity.ToTable("Pasmina");

                entity.Property(e => e.PasminaId).HasColumnName("pasmina_id");

                entity.Property(e => e.NazivPasmine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Naziv_pasmine");

                entity.Property(e => e.VrstaZivotinjeId).HasColumnName("vrsta_zivotinje_id");

                entity.HasOne(d => d.VrstaZivotinje)
                    .WithMany(p => p.Pasminas)
                    .HasForeignKey(d => d.VrstaZivotinjeId)
                    .HasConstraintName("FK_Pasmina_Vrsta_zivotinje");
            });

            modelBuilder.Entity<Skloniste>(entity =>
            {
                entity.ToTable("Skloniste");

                entity.Property(e => e.SklonisteId).HasColumnName("skloniste_id");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.KapacitetSklonista)
                    .HasMaxLength(150)
                    .HasColumnName("Kapacitet_sklonista");

                entity.Property(e => e.NazivSklonista)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("Naziv_sklonista");

                entity.Property(e => e.Telefon).HasMaxLength(50);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Sklonistes)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Skloniste_Grad");
            });

            modelBuilder.Entity<Spol>(entity =>
            {
                entity.ToTable("Spol");

                entity.Property(e => e.SpolId).HasColumnName("spol_id");

                entity.Property(e => e.NazivSpola)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("Naziv_spola");
            });

            modelBuilder.Entity<Udomljavanje>(entity =>
            {
                entity.ToTable("Udomljavanje");

                entity.Property(e => e.UdomljavanjeId).HasColumnName("udomljavanje_id");

                entity.Property(e => e.JeLiZaUdomljavanje)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("je_li_za_udomljavanje");
            });

            modelBuilder.Entity<UoceneLutalice>(entity =>
            {
                entity.ToTable("Uocene_lutalice");

                entity.Property(e => e.UoceneLutaliceId).HasColumnName("uocene_lutalice_id");

                entity.Property(e => e.DatumPrijave)
                    .HasColumnType("date")
                    .HasColumnName("Datum_prijave");

                entity.Property(e => e.GradId).HasColumnName("grad_id");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("opis");

                entity.Property(e => e.Slika)
                    .HasMaxLength(60)
                    .HasColumnName("slika");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.UoceneLutalices)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Uocene_lutalice_Grad");
            });

            modelBuilder.Entity<VrstaZivotinje>(entity =>
            {
                entity.ToTable("Vrsta_zivotinje");

                entity.Property(e => e.VrstaZivotinjeId).HasColumnName("vrsta_zivotinje_id");

                entity.Property(e => e.NazivVrste)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Naziv_vrste");
            });

            modelBuilder.Entity<ZivotinjaUSklonistu>(entity =>
            {
                entity.ToTable("Zivotinja_u_sklonistu");

                entity.Property(e => e.ZivotinjaUSklonistuId).HasColumnName("zivotinja_u_sklonistu_id");

                entity.Property(e => e.AdresaPronalaska)
                    .HasMaxLength(50)
                    .HasColumnName("Adresa_pronalaska");

                entity.Property(e => e.BrojMikrocipa)
                    .HasMaxLength(30)
                    .HasColumnName("Broj_mikrocipa");

                entity.Property(e => e.DatumStenjenja)
                    .HasColumnType("date")
                    .HasColumnName("Datum_stenjenja");

                entity.Property(e => e.ImeZivotinje)
                    .HasMaxLength(50)
                    .HasColumnName("Ime_zivotinje");

                entity.Property(e => e.DatumPronalaska)
                    .HasColumnType("date")
                    .HasColumnName("Datum_pronalaska");

                entity.Property(e => e.KastratId).HasColumnName("kastrat_id");

                entity.Property(e => e.Opis).HasMaxLength(150);

                entity.Property(e => e.PasminaId).HasColumnName("pasmina_id");

                entity.Property(e => e.SklonisteId).HasColumnName("skloniste_id");

                entity.Property(e => e.Slika).HasMaxLength(50);

                entity.Property(e => e.SpolId).HasColumnName("spol_id");

                entity.Property(e => e.UdomljavanjeId).HasColumnName("udomljavanje_id");

                entity.HasOne(d => d.Kastrat)
                    .WithMany(p => p.ZivotinjaUSklonistus)
                    .HasForeignKey(d => d.KastratId)
                    .HasConstraintName("FK_Zivotinja_u_sklonistu_Kastrat");

                entity.HasOne(d => d.Pasmina)
                    .WithMany(p => p.ZivotinjaUSklonistus)
                    .HasForeignKey(d => d.PasminaId)
                    .HasConstraintName("FK_Zivotinja_u_sklonistu_Pasmina");

                entity.HasOne(d => d.Skloniste)
                    .WithMany(p => p.ZivotinjaUSklonistus)
                    .HasForeignKey(d => d.SklonisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zivotinja_u_sklonistu_Skloniste");

                entity.HasOne(d => d.Spol)
                    .WithMany(p => p.ZivotinjaUSklonistus)
                    .HasForeignKey(d => d.SpolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zivotinja_u_sklonistu_Spol");

                entity.HasOne(d => d.Udomljavanje)
                    .WithMany(p => p.ZivotinjaUSklonistus)
                    .HasForeignKey(d => d.UdomljavanjeId)
                    .HasConstraintName("FK_Zivotinja_u_sklonistu_Udomljavanje");
            });

            modelBuilder.Entity<Zupanija>(entity =>
            {
                entity.ToTable("Zupanija");

                entity.Property(e => e.ZupanijaId).HasColumnName("zupanija_id");

                entity.Property(e => e.NazivZupanije)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Naziv_zupanije");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
