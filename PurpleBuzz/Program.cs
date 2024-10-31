using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DataBase;

namespace PurpleBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            var app = builder.Build();
            app.MapDefaultControllerRoute();
            app.UseStaticFiles();
            app.Run();
        }
    }
}
