using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineShopCMS.Data;
using OnlineShopCMS.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineShopCMS.Data
{
    public partial class OnlineShopContext : DbContext
    {
        public OnlineShopContext()
        {
        }

        public OnlineShopContext (DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineShopCMS.Models.Product> Product { get; set; }
        public DbSet<OnlineShopCMS.Models.Category> Category { get; set; }
        public DbSet<OnlineShopCMS.Models.Comment> Comment { get; set; }       //要跟資料庫名稱一樣，由此來操縱資料庫
        public DbSet<OnlineShopCMS.Models.Order> Order { get; set; }
        public DbSet<OnlineShopCMS.Models.OrderItem> OrderItems { get; set; }
        public DbSet<OnlineShopCMS.Models.User> User {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Database=OnlineShop;Trusted_Connection=True;TrustServerCertificate=True;User ID=sa;Password=199911");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

