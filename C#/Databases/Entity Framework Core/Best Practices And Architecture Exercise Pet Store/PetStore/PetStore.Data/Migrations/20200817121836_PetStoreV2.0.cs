using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class PetStoreV20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersFoods");

            migrationBuilder.DropTable(
                name: "CustomersToys");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Foods");

            migrationBuilder.CreateTable(
                name: "FoodsSelled",
                columns: table => new
                {
                    TradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeDate = table.Column<DateTime>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodsSelled", x => x.TradeId);
                    table.ForeignKey(
                        name: "FK_FoodsSelled_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodsSelled_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetsSelled",
                columns: table => new
                {
                    TradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeDate = table.Column<DateTime>(nullable: false),
                    PetId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetsSelled", x => x.TradeId);
                    table.ForeignKey(
                        name: "FK_PetsSelled_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetsSelled_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToysSelled",
                columns: table => new
                {
                    TradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeDate = table.Column<DateTime>(nullable: false),
                    ToyId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToysSelled", x => x.TradeId);
                    table.ForeignKey(
                        name: "FK_ToysSelled_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToysSelled_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "ToyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodsSelled_CustomerId",
                table: "FoodsSelled",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodsSelled_FoodId",
                table: "FoodsSelled",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PetsSelled_CustomerId",
                table: "PetsSelled",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PetsSelled_PetId",
                table: "PetsSelled",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToysSelled_CustomerId",
                table: "ToysSelled",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ToysSelled_ToyId",
                table: "ToysSelled",
                column: "ToyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodsSelled");

            migrationBuilder.DropTable(
                name: "PetsSelled");

            migrationBuilder.DropTable(
                name: "ToysSelled");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Toys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CustomersFoods",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersFoods", x => new { x.CustomerId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_CustomersFoods_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersToys",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ToyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersToys", x => new { x.CustomerId, x.ToyId });
                    table.ForeignKey(
                        name: "FK_CustomersToys_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersToys_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "ToyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersFoods_FoodId",
                table: "CustomersFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersToys_ToyId",
                table: "CustomersToys",
                column: "ToyId");
        }
    }
}
