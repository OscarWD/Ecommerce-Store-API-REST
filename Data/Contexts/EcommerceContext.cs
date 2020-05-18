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
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SubCategorie> SubCategorie { get; set; }
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bills__users_id__1920BF5C");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__billsDeta__bills__1DE57479");

                entity.HasOne(d => d.Products)
                    .WithMany()
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__billsDeta__produ__1ED998B2");
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

                entity.Property(e => e.SubCategorieId).HasColumnName("subCategorie_id");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unitPrice")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.SubCategorie)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubCategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__products__subCat__1BFD2C07");
            });

            modelBuilder.Entity<SubCategorie>(entity =>
            {
                entity.ToTable("subCategorie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoriesId).HasColumnName("categories_id");

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

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.SubCategorie)
                    .HasForeignKey(d => d.CategoriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__subCatego__categ__164452B1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__users__AB6E6164D91B3E3F")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__users__B43B145FF63D405B")
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
