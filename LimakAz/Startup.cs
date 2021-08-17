using Buisness.Abstract;
using Buisness.Concret;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.AutoMapper;
using DataAccess.Concret;
using DataAccess.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace LimakAz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);

            });
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;

            }).AddEntityFrameworkStores<UserDbContext>().AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromMinutes(5));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            }).AddGoogle(o => {
                o.ClientId = Configuration["Authentication:Google:ClientId"];
                o.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

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

            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();
            
            services.AddScoped<IContactContentService, ContactContentManager>();
            services.AddScoped<IContactContentDal, EFContactContentDal>();

            services.AddScoped<IShopContentService, ShopContentManager>();
            services.AddScoped<IShopContentDal, EFShopContentDal>();

            services.AddScoped<ICountryContentService, CountryContentManager>();
            services.AddScoped<ICountryContentDal, EFCountryContentDal>();

            services.AddScoped<ICalculatorInformationContentService, CalculatorInformationContentManager>();
            services.AddScoped<ICalculatorInformationContentDal, EFCalculatorInformationContentDal>();

            services.AddScoped<ICurrencyContentService, CurrencyContentManager>();
            services.AddScoped<ICurrencyContentDal, EFCurrencyContentDal>();

            services.AddScoped<ICalculatorContentService, CalculatorContentManager>();
            services.AddScoped<ICalculatorContentDal, EFCalculatorContentDal>();

            services.AddScoped<IRuleService, RuleManager>();
            services.AddScoped<IRuleDal, EFRuleDal>();

            services.AddScoped<IRuleContentService, RuleContentManager>();
            services.AddScoped<IRuleContentDal, EFRuleContentDal>();

            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IQuestionDal, EFQuestionDal>();

            services.AddScoped<IQuestionContentService, QuestionContentManager>();
            services.AddScoped<IQuestionContentDal, EFQuestionContentDal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EFAboutDal>();

            services.AddScoped<IPrivacyService, PrivacyManager>();
            services.AddScoped<IPrivacyDal, EFPrivacyDal>();

            services.AddScoped<ITariffHeaderService, TariffHeaderManager>();
            services.AddScoped<ITariffHeaderDal, EFTariffHeaderDal>();

            services.AddScoped<IAdvertisementHeaderService, AdvertisementHeaderManager>();
            services.AddScoped<IAdvertisementHeaderDal, EFAdvertisementHeaderDal>();

            services.AddScoped<IUserRuleService, UserRuleManager>();
            services.AddScoped<IUserRuleDal, EFUserRuleDal>();

            services.AddScoped<IRegisterContentService, RegisterContentManager>();
            services.AddScoped<IRegisterContentDal, EFRegisterContentDal>();

            services.AddScoped<IRegisterInformationService, RegisterInformationManager>();
            services.AddScoped<IRegisterInformationDal, EFRegisterInformationDal>();

            services.AddScoped<IGenderService, GenderManager>();
            services.AddScoped<IGenderDal, EFGenderDal>();

            services.AddScoped<ILoginContentService, LoginContentManager>();
            services.AddScoped<ILoginContentDal, EFLoginContentDal>();

            services.AddScoped<IForgotPasswordContentService, ForgotPasswordContentManager>();
            services.AddScoped<IForgotPasswordContentDal, EFForgotPasswordContentDal>();

            services.AddScoped<IExpiredVerifyEmailTokenService, ExpiredVerifyEmailTokenManager>();
            services.AddScoped<IExpiredVerifyEmailTokenDal, EFExpiredVerifyEmailToken>();

            services.AddScoped<IResetPasswordExpiredTokenService, ResetPasswordExpiredTokenManager>();
            services.AddScoped<IResetPasswordExpiredTokenDal, EFResetPasswordExpiredTokenDal>();

            services.AddScoped<IBalanceContentService, BalanceContentMananger>();
            services.AddScoped<IBalanceContentDal, EFBalanceContentDal>();

            services.AddScoped<IAddressContentService, AddressContentManager>();
            services.AddScoped<IAddressContentDal, EFAddressContentDal>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LimakAz", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LimakAz v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
