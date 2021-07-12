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
    }
}
