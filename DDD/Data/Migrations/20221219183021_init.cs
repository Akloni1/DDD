using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DDD.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyersRoot",
                columns: table => new
                {
                    IdBuyerRoot = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gender = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyersRoot", x => x.IdBuyerRoot);
                });

            migrationBuilder.CreateTable(
                name: "OrdersRoot",
                columns: table => new
                {
                    IdOrderRoot = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersRoot", x => x.IdOrderRoot);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    IdBuyer = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeCard = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    PaymentMethod = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    IdBuyerRoot = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.IdBuyer);
                    table.ForeignKey(
                        name: "FK_BuyerRoot_Buyers",
                        column: x => x.IdBuyerRoot,
                        principalTable: "BuyersRoot",
                        principalColumn: "IdBuyerRoot");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderStatus = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    ListDecoctions = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    IdOrderRoot = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_OrderRoot_Orders",
                        column: x => x.IdOrderRoot,
                        principalTable: "OrdersRoot",
                        principalColumn: "IdOrderRoot");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_IdBuyerRoot",
                table: "Buyers",
                column: "IdBuyerRoot");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdOrderRoot",
                table: "Orders",
                column: "IdOrderRoot");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BuyersRoot");

            migrationBuilder.DropTable(
                name: "OrdersRoot");
        }
    }
}
