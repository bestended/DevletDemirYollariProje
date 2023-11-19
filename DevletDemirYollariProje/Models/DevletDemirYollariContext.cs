using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevletDemirYollariProje.Models
{
    public partial class DevletDemirYollariContext : DbContext
    {
        public DevletDemirYollariContext()
        {
        }

        public DevletDemirYollariContext(DbContextOptions<DevletDemirYollariContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kurumlar> Kurumlars { get; set; } = null!;
        public virtual DbSet<Musteriler> Musterilers { get; set; } = null!;
        public virtual DbSet<Peronlar> Peronlars { get; set; } = null!;
        public virtual DbSet<Personeller> Personellers { get; set; } = null!;
        public virtual DbSet<Trenler> Trenlers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1PBLKBH\\SQLEXPRESS; Database=DevletDemirYollari; uid=sa; pwd=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kurumlar>(entity =>
            {
                entity.HasKey(e => e.KurumId);

                entity.ToTable("Kurumlar");

                entity.Property(e => e.KurulusTarihi).HasColumnType("datetime");

                entity.Property(e => e.KurumAdi).HasMaxLength(50);

                entity.Property(e => e.KurumMerkezi).HasMaxLength(50);

                entity.HasOne(d => d.Peron)
                    .WithMany(p => p.Kurumlars)
                    .HasForeignKey(d => d.PeronId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kurumlar_Peronlar");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.Kurumlars)
                    .HasForeignKey(d => d.PersonelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kurumlar_Personeller");
            });

            modelBuilder.Entity<Musteriler>(entity =>
            {
                entity.HasKey(e => e.MusteriId);

                entity.ToTable("Musteriler");

                entity.Property(e => e.Ad).HasMaxLength(50);

                entity.Property(e => e.Cinsiyet).HasMaxLength(50);

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Soyad).HasMaxLength(50);

                entity.Property(e => e.TcKimlikNo)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefon).HasMaxLength(50);

                entity.HasOne(d => d.Tren)
                    .WithMany(p => p.Musterilers)
                    .HasForeignKey(d => d.TrenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Musteriler_Trenler");
            });

            modelBuilder.Entity<Peronlar>(entity =>
            {
                entity.HasKey(e => e.PeronId);

                entity.ToTable("Peronlar");

                entity.Property(e => e.PeronMevki).HasMaxLength(50);
            });

            modelBuilder.Entity<Personeller>(entity =>
            {
                entity.HasKey(e => e.PersonelId);

                entity.ToTable("Personeller");

                entity.Property(e => e.Adi).HasMaxLength(50);

                entity.Property(e => e.Adresi).HasMaxLength(50);

                entity.Property(e => e.Soyadi).HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(50);
            });

            modelBuilder.Entity<Trenler>(entity =>
            {
                entity.HasKey(e => e.TrenId);

                entity.ToTable("Trenler");

                entity.Property(e => e.KalkisTarihSaat).HasColumnType("datetime");

                entity.Property(e => e.KalkisYön).HasMaxLength(50);

                entity.Property(e => e.TrenTipi).HasMaxLength(50);

                entity.Property(e => e.VarisTarihSaat).HasColumnType("datetime");

                entity.Property(e => e.VarisYön).HasMaxLength(50);

                entity.HasOne(d => d.Kurum)
                    .WithMany(p => p.Trenlers)
                    .HasForeignKey(d => d.KurumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trenler_Kurumlar");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
