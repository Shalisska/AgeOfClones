using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Migrations
{
    public partial class SocialStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Benefit = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    BenefitTimeDays = table.Column<int>(nullable: false),
                    HaveKingdom = table.Column<bool>(nullable: false),
                    HavePalace = table.Column<bool>(nullable: false),
                    HaveTown = table.Column<bool>(nullable: false),
                    LicenseCount = table.Column<int>(nullable: false),
                    LicensePrice = table.Column<int>(nullable: false),
                    MaxFields = table.Column<int>(nullable: false),
                    MaxNumberOfLivestock = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PerformanceCostPerDay = table.Column<int>(nullable: false),
                    PriceForAllLicenses = table.Column<int>(nullable: false),
                    RaiseFlag = table.Column<bool>(nullable: false),
                    ReferralPaymentsClonero = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    TimeToGetLicence = table.Column<int>(nullable: false),
                    TownManufacturingLevel = table.Column<int>(nullable: false),
                    UniversityLevel = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialStatuses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialStatuses");
        }
    }
}
