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
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext (DbContextOptions<OnlineShopContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineShopCMS.Models.Product> Product { get; set; } 
        public DbSet<OnlineShopCMS.Models.Category> Category { get; set; }
        public DbSet<OnlineShopCMS.Models.Comment> Comment { get; set; }       //要跟資料庫名稱一樣，由此來操縱資料庫
        public DbSet<OnlineShopCMS.Models.Order> Order { get; set; }
        public DbSet<OnlineShopCMS.Models.OrderItem> OrderItems { get; set; }
		
	}
}


