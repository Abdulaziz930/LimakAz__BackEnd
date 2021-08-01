using Entities.Dto;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1QPG03B;Database=LimakAzDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<AdvertisementDetail> AdvertisementDetails { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Calculator> Calculators { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Weight> Weights { get; set; }

        public DbSet<UnitsOfLength> UnitsOfLengths { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<HowItWork> HowItWorks { get; set; }

        public DbSet<HowItWorkCard> HowItWorkCards { get; set; }

        public DbSet<Tariff> Tariffs { get; set; }
        
        public DbSet<Certificate> Certificates { get; set; }

        public DbSet<CertifcateContent> CertifcateContents { get; set; }

        public DbSet<AdvertisimentTitle> AdvertisimentTitles { get; set; }

        public DbSet<CountryProductType> CountryProductTypes { get; set; }

        public DbSet<Tab> Tabs { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<ShopCountry> ShopCountries { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Service> Services { get; set; }
    }
}
