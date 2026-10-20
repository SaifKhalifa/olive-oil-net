using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OliveOil.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OliveOilProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerLiter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OliveOilProducts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OliveOilProducts",
                columns: new[] { "Id", "Name", "PricePerLiter", "QuantityInStock", "Region" },
                values: new object[,]
                {
                    { 1, "nablus oil - 1", 99m, 10, "nablus" },
                    { 2, "jenin oil - 2", 99m, 10, "jenin" },
                    { 3, "hebron oil - 3", 99m, 10, "hebron" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OliveOilProducts");
        }
    }
}
