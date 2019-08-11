using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Migrations
{
    public partial class GoodsOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Accounts_AccountEFId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Stocks_StockId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyExchangeRates_Currencies_CurrencyId",
                table: "CurrencyExchangeRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currencies");

            migrationBuilder.RenameIndex(
                name: "IX_Currencies_StockId",
                table: "Currencies",
                newName: "IX_Currencies_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_Currencies_AccountEFId",
                table: "Currencies",
                newName: "IX_Currencies_AccountEFId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GoodsType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    PriceBase = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    StockId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfClosing = table.Column<DateTime>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    GoodsId = table.Column<int>(nullable: false),
                    IsFullyUsed = table.Column<bool>(nullable: false),
                    OperationDirection = table.Column<int>(nullable: false),
                    OperationStatus = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlockType = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false),
                    ParticipantType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageIdentities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goods_StockId",
                table: "Goods",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Accounts_AccountEFId",
                table: "Currencies",
                column: "AccountEFId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Stocks_StockId",
                table: "Currencies",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyExchangeRates_Currencies_CurrencyId",
                table: "CurrencyExchangeRates",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Accounts_AccountEFId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_Stocks_StockId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyExchangeRates_Currencies_CurrencyId",
                table: "CurrencyExchangeRates");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "StorageIdentities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currencies");

            migrationBuilder.RenameIndex(
                name: "IX_Currencies_StockId",
                table: "Currencies",
                newName: "IX_Currencies_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_Currencies_AccountEFId",
                table: "Currencies",
                newName: "IX_Currencies_AccountEFId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Accounts_AccountEFId",
                table: "Currencies",
                column: "AccountEFId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_Stocks_StockId",
                table: "Currencies",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyExchangeRates_Currencies_CurrencyId",
                table: "CurrencyExchangeRates",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
