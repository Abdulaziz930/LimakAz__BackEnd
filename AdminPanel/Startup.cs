using Buisness.Abstract;
using Buisness.Concret;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.AutoMapper;
using DataAccess.Concret;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace AdminPanel
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _environment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IAdvertisementService, AdvertisementManager>();
            services.AddScoped<IAdvertisementDal, EFAdvertisementDal>();

            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<ILangaugeDal, EFLanguageDal>();

            services.AddScoped<ICertificateContentService, CertificateContentManager>();
            services.AddScoped<ICertificateContentDal, EFCertificateContentDal>();

            services.AddScoped<IAdvertisementTitleService, AdvertisementTitleManger>();
            services.AddScoped<IAdvertisementTitleDal, EFAdvertisementTitleDal>();

            services.AddScoped<ICalculatorService, CalculatorManger>();
            services.AddScoped<ICalculatorDal, EFCalculatorDal>();

            services.AddScoped<ICertificateService, CertificateManager>();
            services.AddScoped<ICertificateDal, EFCertificateDal>();

            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICityDal, EFCityDal>();

            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<ICountryDal, EFCountryDal>();

            services.AddScoped<IHowItWorkService, HowItWorkManager>();
            services.AddScoped<IHowItWorkDal, EFHowItWorkDal>();

            services.AddScoped<IHowItWorkCardService, HowItWorkCardManager>();
            services.AddScoped<IHowItWorkCardDal, EFHowItWorkCardDal>();

            services.AddScoped<IProductTypeService, ProductTypeManager>();
            services.AddScoped<IProductTypeDal, EFProductTypeDal>();

            services.AddScoped<IUnitsOfLengthService, UnitsOfLengthManager>();
            services.AddScoped<IUnitsOfLengthDal, EFUnitsOfLengthDal>();

            services.AddScoped<IWeightService, WeightManager>();
            services.AddScoped<IWeightDal, EFWeightDal>();

            services.AddScoped<ITariffService, TariffManager>();
            services.AddScoped<ITariffDal, EFTariffDal>();

            services.AddScoped<IShopService, ShopManager>();
            services.AddScoped<IShopDal, EFShopDal>();

            services.AddControllersWithViews();

            Constants.ImageFolderPath = Path.Combine(_environment.WebRootPath, "img");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            });
        }
    }
}
