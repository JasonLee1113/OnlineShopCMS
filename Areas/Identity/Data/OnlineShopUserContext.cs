﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShopCMS.Areas.Identity.Data;

namespace OnlineShopCMS.Data;

public class OnlineShopUserContext : IdentityDbContext<OnlineShopUser>
{
    public OnlineShopUserContext(DbContextOptions<OnlineShopUserContext> options)
        : base(options)
    {
    }

	public DbSet<OnlineShopCMS.Areas.Identity.Data.OnlineShopUserRole> OnlineShopUserRole { get; set; }
	public DbSet<OnlineShopCMS.Areas.Identity.Data.OnlineShopUser> OnlineShopUser { get; set; }
	protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


    }
}
