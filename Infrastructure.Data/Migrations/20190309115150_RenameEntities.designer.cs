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
    [Migration("20190309115150_Rename entities")]
    partial class Renameentities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Infrastructure.Data.Entities.CloneEF", b =>
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

            modelBuilder.Entity("Infrastructure.Data.Entities.CurrencyEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountEFId");

                    b.Property<string>("Name");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("AccountEFId");

                    b.HasIndex("StockId");

                    b.ToTable("Currecies");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CurrencyExchangeRateEF", b =>
                {
                    b.Property<int>("CurrencyId");

                    b.Property<int>("CurrencyPairId");

                    b.Property<decimal>("Buy")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal>("Sell")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("CurrencyId", "CurrencyPairId");

                    b.ToTable("CurrencyExchangeRates");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.ProfileEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.ResourceEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountEFId");

                    b.Property<string>("Name");

                    b.Property<int>("Performance");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<decimal>("PriceBase")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("StockId");

                    b.HasKey("Id");

                    b.HasIndex("AccountEFId");

                    b.HasIndex("StockId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.StockEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.AccountEF", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.ProfileEF", "Profile")
                        .WithMany("Accounts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CloneEF", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.AccountEF", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CurrencyEF", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.AccountEF")
                        .WithMany("Currencies")
                        .HasForeignKey("AccountEFId");

                    b.HasOne("Infrastructure.Data.Entities.StockEF", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.CurrencyExchangeRateEF", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.CurrencyEF", "Currency")
                        .WithMany("ExchangeRates")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Infrastructure.Data.Entities.ResourceEF", b =>
                {
                    b.HasOne("Infrastructure.Data.Entities.AccountEF")
                        .WithMany("Resources")
                        .HasForeignKey("AccountEFId");

                    b.HasOne("Infrastructure.Data.Entities.StockEF", "Stock")
                        .WithMany("Resources")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}