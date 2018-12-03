﻿// <auto-generated />
using Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ClonesContextEF))]
    partial class ClonesContextEFModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Data.Entities.AccountEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Clone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<int>("Age");

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<string>("Name");

                    b.Property<decimal>("Performance")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Clones");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CurrencyExchangeRate", b =>
                {
                    b.Property<int>("CurrencyId");

                    b.Property<int>("CurrencyPairId");

                    b.Property<decimal>("Buy")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal>("Sell")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("CurrencyId", "CurrencyPairId");

                    b.ToTable("CurrencyExchanges");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Performance");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal>("PriceBase")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.SocialStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Benefit")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("BenefitTimeDays");

                    b.Property<bool>("HaveKingdom");

                    b.Property<bool>("HavePalace");

                    b.Property<bool>("HaveTown");

                    b.Property<int>("LicenseCount");

                    b.Property<decimal>("LicensePrice")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("MaxFields");

                    b.Property<int>("MaxNumberOfLivestock");

                    b.Property<string>("Name");

                    b.Property<int>("PerformanceCostPerDay");

                    b.Property<decimal>("PriceForAllLicenses")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<bool>("RaiseFlag");

                    b.Property<decimal>("ReferralPaymentsClonero")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("TimeToGetLicenceHours");

                    b.Property<int>("TownManufacturingLevel");

                    b.Property<int>("UniversityLevel");

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.ToTable("SocialStatuses");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.WalletEF", b =>
                {
                    b.Property<int>("AccountId");

                    b.Property<int>("CurrencyId");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("AccountId", "CurrencyId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.AccountEF", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.Profile", "Profile")
                        .WithMany("Accounts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Clone", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.AccountEF", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Currency", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CurrencyExchangeRate", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.Currency", "Currency")
                        .WithMany("ExchangeRates")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.Resource", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.Stock", "Stock")
                        .WithMany("Resources")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.WalletEF", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.AccountEF", "Account")
                        .WithMany("Wallets")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Infrastructure.Data.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
