using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Migrations
{
    public partial class socialStatusDecimalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeToGetLicence",
                table: "SocialStatuses",
                newName: "TimeToGetLicenceHours");

            migrationBuilder.AlterColumn<decimal>(
                name: "PriceForAllLicenses",
                table: "SocialStatuses",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "LicensePrice",
                table: "SocialStatuses",
                type: "decimal(18, 4)",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeToGetLicenceHours",
                table: "SocialStatuses",
                newName: "TimeToGetLicence");

            migrationBuilder.AlterColumn<int>(
                name: "PriceForAllLicenses",
                table: "SocialStatuses",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");

            migrationBuilder.AlterColumn<int>(
                name: "LicensePrice",
                table: "SocialStatuses",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)");
        }
    }
}
