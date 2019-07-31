using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Migrations
{
    public partial class Renameentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyExchanges");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.AddColumn<int>(
                name: "AccountEFId",
                table: "Resources",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountEFId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_Accounts_AccountEFId",
                        column: x => x.AccountEFId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currencies_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchangeRates",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyPairId = table.Column<int>(nullable: false),
                    Buy = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Sell = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchangeRates", x => new { x.CurrencyId, x.CurrencyPairId });
                    table.ForeignKey(
                        name: "FK_CurrencyExchangeRates_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_AccountEFId",
                table: "Resources",
                column: "AccountEFId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_AccountEFId",
                table: "Currencies",
                column: "AccountEFId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_StockId",
                table: "Currencies",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Accounts_AccountEFId",
                table: "Resources",
                column: "AccountEFId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Accounts_AccountEFId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "CurrencyExchangeRates");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Resources_AccountEFId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "AccountEFId",
                table: "Resources");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchanges",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false),
                    CurrencyPairId = table.Column<int>(nullable: false),
                    Buy = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Sell = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchanges", x => new { x.CurrencyId, x.CurrencyPairId });
                    table.ForeignKey(
                        name: "FK_CurrencyExchanges_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_StockId",
                table: "Currencies",
                column: "StockId");
        }
    }
}
