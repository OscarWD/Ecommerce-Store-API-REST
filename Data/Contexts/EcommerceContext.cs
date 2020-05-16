using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EcommerceStoreAPI.Models;

namespace EcommerceStoreAPI.Data.Contexts
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<BillsDetails> BillsDetails { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CategoriesProducts> CategoriesProducts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.ToTable("bills");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__bills__users_id__145C0A3F");
            });

            modelBuilder.Entity<BillsDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("billsDetails");

                entity.Property(e => e.BillsId).HasColumnName("bills_id");

                entity.Property(e => e.ProductsId).HasColumnName("products_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unitPrice")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Bills)
                    .WithMany()
                    .HasForeignKey(d => d.BillsId)
                    .HasConstraintName("FK__billsDeta__bills__182C9B23");

                entity.HasOne(d => d.Products)
                    .WithMany()
                    .HasForeignKey(d => d.ProductsId)
                    .HasConstraintName("FK__billsDeta__produ__1920BF5C");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoriesProducts>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("categories_products");

                entity.Property(e => e.CategoriesId).HasColumnName("categories_id");

                entity.Property(e => e.ProductsId).HasColumnName("products_id");

                entity.HasOne(d => d.Categories)
                    .WithMany()
                    .HasForeignKey(d => d.CategoriesId)
                    .HasConstraintName("FK__categorie__categ__24927208");

                entity.HasOne(d => d.Products)
                    .WithMany()
                    .HasForeignKey(d => d.ProductsId)
                    .HasConstraintName("FK__categorie__produ__25869641");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BuyPrice)
                    .HasColumnName("buyPrice")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unitPrice")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__users__AB6E6164178D0745")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__users__B43B145F21824B2C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AvatarUrl)
                    .HasColumnName("avatarURL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LasName)
                    .IsRequired()
                    .HasColumnName("lasName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
