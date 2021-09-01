﻿using AutoMapper.Configuration;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

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

        public DbSet<Tab> Tabs { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<ShopCountry> ShopCountries { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ContactContent> ContactContents { get; set; }

        public DbSet<ShopContent> ShopContents { get; set; }

        public DbSet<CountryContent> CountryContents { get; set; }

        public DbSet<CalculatorIntormationContent> CalculatorIntormationContents { get; set; }

        public DbSet<CurrencyContent> CurrencyContents { get; set; }

        public DbSet<CalculatorContent> CalculatorContents { get; set; }

        public DbSet<Rule> Rules { get; set; }

        public DbSet<RuleContent> RuleContents { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionContent> QuestionContents { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Privacy> Privacies { get; set; }

        public DbSet<TariffHeader> TariffHeaders { get; set; }

        public DbSet<AdvertisementHeader> AdvertisementHeaders { get; set; }

        public DbSet<UserRule> UserRules { get; set; }

        public DbSet<RegisterContent> RegisterContents { get; set; }

        public DbSet<RegisterInformation> RegisterInformations { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<LoginContent> LoginContents { get; set; }

        public DbSet<ForgotPasswordContent> ForgotPasswordContents { get; set; }

        public DbSet<ExpiredVerifyEmailToken> ExpiredVerifyEmailTokens { get; set; }

        public DbSet<ResetPasswordExpiredToken> ResetPasswordExpiredTokens { get; set; }

        public DbSet<BalanceContent> BalanceContents { get; set; }

        public DbSet<AddressContent> AddressContents { get; set; }

        public DbSet<SettingContent> SettingContents { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<BalanceModalContent> BalanceModalContents { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<OrderContent> OrderContents { get; set; }
    }
}
