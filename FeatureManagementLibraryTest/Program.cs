using FeatureManagementLibraryTest.Features;
using FeatureManagementLibraryTest.Features.FeatureE;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

namespace FeatureManagementLibraryTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpClient();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddFeatureManagement(builder.Configuration.GetSection("FeatureManagement"))
                            .UseDisabledFeaturesHandler(new CustomDisabledFeaturesHandler())
                            .AddFeatureFilter<PercentageFilter>()
                            .AddFeatureFilter<FeatureEFilter>()
                            .AddFeatureFilter<FeatureF>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void AddFeatureFilter<T>()
        {
            throw new NotImplementedException();
        }
    }
}