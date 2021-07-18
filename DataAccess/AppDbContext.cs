using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<AdvertisementDetail> AdvertisementDetails { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<AuxiliarySection> AuxiliarySections { get; set; }

        public DbSet<Authentication> Authentications { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Calculator> Calculators { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Weight> Weights { get; set; }

        public DbSet<WeightInput> WeightInputs { get; set; }

        public DbSet<UnitsOfLength> UnitsOfLengths { get; set; }

        public DbSet<WidthInput> WidthInputs { get; set; }

        public DbSet<HeightInput> HeightInputs { get; set; }

        public DbSet<LengthInput> LengthInputs { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<BoxCountInput> BoxCountInputs { get; set; }

        public DbSet<HowItWork> HowItWorks { get; set; }

        public DbSet<HowItWorkCard> HowItWorkCards { get; set; }
    }
}
