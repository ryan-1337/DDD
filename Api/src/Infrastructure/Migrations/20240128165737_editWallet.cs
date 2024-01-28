using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "ID", "CODE", "NAME" },
                values: new object[,]
                {
                    { "1", "EUR", "Euro" },
                    { "2", "USD", "Dollar" },
                    { "3", "GBP", "Livre Sterling" },
                    { "4", "JPY", "Yen" },
                    { "5", "CHF", "Franc Suisse" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "NAME", "OPTIONS", "PRICE_PER_NIGHT" },
                values: new object[,]
                {
                    { "1", "Standard", "[\"Lit 1 place\",\"Wifi\",\"TV\"]", 50m },
                    { "2", "Supérieure", "[\"Lit 2 places\",\"Wifi\",\"TV \\u00E9cran plat\",\"Minibar\",\"Climatiseur\"]", 100m },
                    { "3", "Suite", "[\"Lit 2 places\",\"Wifi\",\"TV \\u00E9cran plat\",\"Minibar\",\"Climatiseur\",\"Baignoire\",\"Terrasse\"]", 200m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: "3");
        }
    }
}
