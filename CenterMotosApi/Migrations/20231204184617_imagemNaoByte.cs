using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CenterMotosApi.Migrations
{
    /// <inheritdoc />
    public partial class imagemNaoByte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Descricao_Produto", "Foto_Produto", "Nome_Produto", "Preco" },
                values: new object[,]
                {
                    { 1, "Retrovisor Titan 150 / 160 2014- Esquerdo MOD Original (GVS) Cada - 4001", null, "Retrovisor", 19.00m },
                    { 2, "Capacete PRO TORK V-PRO JET 3 Articulado", null, "Capacete", 208.99m },
                    { 3, "Bateria Pioneiro YTX7LBS (MBR7-BS) Selada Falcon / Twister / Tornado / Fazer 250 / Lander / TITAN150", null, "Bateria", 162.75m }
                });
        }
    }
}
