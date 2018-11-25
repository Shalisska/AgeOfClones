using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Migrations
{
    public partial class ExchangeRateBuySell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "CurrencyExchanges",
                newName: "Sell");

            migrationBuilder.AddColumn<decimal>(
                name: "Buy",
                table: "CurrencyExchanges",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buy",
                table: "CurrencyExchanges");

            migrationBuilder.RenameColumn(
                name: "Sell",
                table: "CurrencyExchanges",
                newName: "Price");
        }
    }
}
