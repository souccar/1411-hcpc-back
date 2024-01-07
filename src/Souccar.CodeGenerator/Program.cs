using Souccar;

namespace Souccar.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Files : ");
            var assembly = typeof(SouccarCoreModule).Assembly;
            ModulesBuilder.Generate(assembly, "Hcpc");
            //LocalizationBuilder.Generate(assembly, "Kit");
            //DbContextBuilder.Generate(assembly, "Kit");
            //PermissionsBuilder.Generate(assembly, "Kit");

            Console.WriteLine("Files : " + GeneralSetting.FileCount);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            
        }
    }
}



