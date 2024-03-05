using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShopCMS.Data;
using Microsoft.AspNetCore.Identity;
namespace OnlineShopCMS
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//�ӫ~��ƮwDI container
			builder.Services.AddDbContext<OnlineShopContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopContext") ?? throw new InvalidOperationException("Connection string 'OnlineShopContext' not found.")));

			builder.Services.AddSession();      //���USession�A��

            //Login DI container
            //		builder.Services.AddDbContext<OnlineShopUserContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopUserContext") ?? throw new InvalidOperationException("Connection string 'OnlineShopUserContext' not found.")));


            //		builder.Services.AddDefaultIdentity<OnlineShopUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OnlineShopUserContext>();

            //builder.Services.AddDefaultIdentity<OnlineShopUser>(options =>
            //{
            //	options.Password.RequiredLength = 4;             //�K�X����
            //	options.Password.RequireLowercase = false;       //�]�t�p�g�^��
            //	options.Password.RequireUppercase = false;       //�]�t�j�g�^��
            //	options.Password.RequireNonAlphanumeric = false; //�]�t�Ÿ�
            //	options.Password.RequireDigit = false;           //�]�t�Ʀr
            //})
            //.AddRoles<IdentityRole>() //����
            //.AddEntityFrameworkStores<OnlineShopUserContext>();



            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OnlineShopUserContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseSession();			//���USession�A��

			app.UseAuthentication();  // .net core identity

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapRazorPages();
			//});

			//app.MapRazorPages();

			app.Run();


		}
	}
}
