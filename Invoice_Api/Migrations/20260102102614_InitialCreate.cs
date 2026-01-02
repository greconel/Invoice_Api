using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invoice_Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name" },
                values: new object[,]
                {
                    { 1, "Molunguri, A" },
                    { 2, "Muhinyi, Mauda" },
                    { 3, "Antony, Abdul" },
                    { 4, "Smith, Ahmad" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CustomerId", "InvoiceDate", "InvoiceTotal", "ProductTotal", "SalesTax", "Shipping" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2010, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 178.25m, 160.00m, 12.00m, 6.25m },
                    { 2, 2, new DateTime(2010, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.94m, 62.50m, 4.69m, 3.75m },
                    { 3, 3, new DateTime(2010, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.13m, 45.00m, 3.38m, 3.75m },
                    { 4, 2, new DateTime(2010, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.94m, 62.50m, 4.69m, 3.75m },
                    { 5, 4, new DateTime(2010, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.94m, 62.50m, 4.69m, 3.75m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
