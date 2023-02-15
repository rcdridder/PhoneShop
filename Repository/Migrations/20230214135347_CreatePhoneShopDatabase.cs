using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreatePhoneShopDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    PhoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceNoVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phones_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { 1, "Apple" },
                    { 2, "Google" },
                    { 3, "Huawei" },
                    { 4, "Samsung" },
                    { 5, "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "PhoneId", "BrandId", "Description", "Model", "PriceNoVat", "PriceVat", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Met de dubbele camera schiet je in elke situatie een perfecte foto of video. De krachtige A13-chipset zorgt voor razendsnelle prestaties. Met Face ID hoef je enkel en alleen naar je toestel te kijken om te ontgrendelen. Het toestel heeft een lange accuduur dankzij een energiezuinige processor", "iPhone 11", 0m, 619m, 5 },
                    { 2, 2, "12.2 megapixel camera, 4k videokwaliteit 5.81 inch OLED scherm, 128 GB opslaggeheugen 3140 mAh accucapaciteit", "Pixel 4a", 0m, 411m, 5 },
                    { 3, 3, "6.47\" FHD+ (2340x1080) OLED, Kirin 980 Octa-Core (2x Cortex-A76 2.6GHz + 2x Cortex-A76 1.92GHz + 4x Cortex-A55 1.8GHz), 8GB RAM, 128GB ROM, 40+20+8+TOF/32MP, Dual SIM, 4200mAh, Android 9.0 + EMUI 9.1", "P30", 0m, 697m, 5 },
                    { 4, 4, "64 megapixel camera, 4k videokwaliteit 6.5 inch AMOLED scherm 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd) Water- en stofbestendig (IP67)", "Galaxy A52", 0m, 399m, 5 },
                    { 5, 5, "108 megapixel camera, 4k videokwaliteit 6.67 inch AMOLED scherm, 128 GB opslaggeheugen (Uitbreidbaar met Micro-sd). Water- en stofbestendig (IP53)", "Xiaomi", 0m, 298m, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_BrandId",
                table: "Phones",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
