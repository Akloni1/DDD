using DDD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Data
{
    public partial class DDDContext : DbContext
    {
        public DDDContext()
        {
        }

        public DDDContext(DbContextOptions<DDDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderRoot> OrdersRoot { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<BuyerRoot> BuyersRoot { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DDD;Username=postgres;Password=admin");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyerRoot>(entity =>
            {
                entity.HasKey(e => e.IdBuyerRoot);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);
               
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasKey(e => e.IdBuyer);

                entity.Property(e => e.TypeCard)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(500)
                    .IsUnicode(false);


                entity.HasOne(d => d.BuyerRoot)
                  .WithMany(p => p.Buyers)
                  .HasForeignKey(d => d.IdBuyerRoot)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_BuyerRoot_Buyers");
            });



            modelBuilder.Entity<OrderRoot>(entity =>
            {
                entity.HasKey(e => e.IdOrderRoot);

                

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ListDecoctions)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                   .HasMaxLength(500)
                   .IsUnicode(false);


                entity.HasOne(d => d.OrderRoot)
                  .WithMany(p => p.Orders)
                  .HasForeignKey(d => d.IdOrderRoot)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_OrderRoot_Orders");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
