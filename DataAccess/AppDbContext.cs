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
    }
}
