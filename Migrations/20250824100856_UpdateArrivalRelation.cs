using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArrivalRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_UnitOfMeasurement_UnitOfMeasurementId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOfMeasurement",
                table: "UnitOfMeasurement");

            migrationBuilder.RenameTable(
                name: "UnitOfMeasurement",
                newName: "UnitsOfMeasurement");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOfMeasurement_Name",
                table: "UnitsOfMeasurement",
                newName: "IX_UnitsOfMeasurement_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitsOfMeasurement",
                table: "UnitsOfMeasurement",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Arrivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrivals_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arrivals_ResourceId",
                table: "Arrivals",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_UnitsOfMeasurement_UnitOfMeasurementId",
                table: "Resources",
                column: "UnitOfMeasurementId",
                principalTable: "UnitsOfMeasurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_UnitsOfMeasurement_UnitOfMeasurementId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "Arrivals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitsOfMeasurement",
                table: "UnitsOfMeasurement");

            migrationBuilder.RenameTable(
                name: "UnitsOfMeasurement",
                newName: "UnitOfMeasurement");

            migrationBuilder.RenameIndex(
                name: "IX_UnitsOfMeasurement_Name",
                table: "UnitOfMeasurement",
                newName: "IX_UnitOfMeasurement_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOfMeasurement",
                table: "UnitOfMeasurement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_UnitOfMeasurement_UnitOfMeasurementId",
                table: "Resources",
                column: "UnitOfMeasurementId",
                principalTable: "UnitOfMeasurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
