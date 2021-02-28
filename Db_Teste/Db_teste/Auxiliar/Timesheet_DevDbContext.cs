using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Db_teste.Auxiliar
{
    public partial class Timesheet_DevDbContext : DbContext
    {
        public Timesheet_DevDbContext()
        {
        }

        public Timesheet_DevDbContext(DbContextOptions<Timesheet_DevDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Nivel> Nivel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=23.102.32.185;Database=Sybase_Sybase_Timesheet_Dev;user=timesheet_dev;password=timesheet_dev;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nivel>(entity =>
            {
                entity.ToTable("NIVEL");

                entity.Property(e => e.Nivelid)
                    .HasColumnName("nivelid")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Abonos)
                    .HasColumnName("abonos")
                    .HasColumnType("money");

                entity.Property(e => e.Atribviatura)
                    .HasColumnName("atribviatura")
                    .HasColumnType("money");

                entity.Property(e => e.Desc)
                    .HasColumnName("desc")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Despesas)
                    .HasColumnName("despesas")
                    .HasColumnType("money");

                entity.Property(e => e.Despesasgasolina)
                    .HasColumnName("despesasgasolina")
                    .HasColumnType("money");

                entity.Property(e => e.Despesasviatura)
                    .HasColumnName("despesasviatura")
                    .HasColumnType("money");

                entity.Property(e => e.Premio)
                    .HasColumnName("premio")
                    .HasColumnType("money");

                entity.Property(e => e.Shortdesc)
                    .HasColumnName("shortdesc")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Subsrefeicao)
                    .HasColumnName("subsrefeicao")
                    .HasColumnType("money");

                entity.Property(e => e.Variavel)
                    .HasColumnName("variavel")
                    .HasColumnType("money");

                entity.Property(e => e.Vencimento)
                    .HasColumnName("vencimento")
                    .HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
