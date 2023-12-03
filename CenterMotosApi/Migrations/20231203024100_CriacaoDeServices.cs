using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CenterMotosApi.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDeServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome_Produto",
                table: "Comentario",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Cliente",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "CarrinhoId", "CPF", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, null, "12345678910", "Mauricio", "123456" },
                    { 2, null, "12345678911", "Antonio", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Mecanico",
                columns: new[] { "Id", "CPF", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, "12345678912", "Thiago", "123456" },
                    { 2, "12345678913", "Birobiro", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Descricao_Produto", "Foto_Produto", "Nome_Produto", "Preco" },
                values: new object[,]
                {
                    { 1, "Retrovisor Titan 150 / 160 2014- Esquerdo MOD Original (GVS) Cada - 4001", null, "Retrovisor", 19.00m },
                    { 2, "Capacete PRO TORK V-PRO JET 3 Articulado", null, "Capacete", 208.99m },
                    { 3, "Bateria Pioneiro YTX7LBS (MBR7-BS) Selada Falcon / Twister / Tornado / Fazer 250 / Lander / TITAN150", null, "Bateria", 162.75m }
                });

            migrationBuilder.InsertData(
                table: "Carrinho",
                columns: new[] { "Id", "ClienteId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "Id", "ClienteId", "DescricaoComentario", "Nome", "Nome_Produto", "ProdutoId" },
                values: new object[,]
                {
                    { 1, 1, "Retrovisor excelente, bonito e barato", "aleatorio", "nada", 1 },
                    { 2, 2, "Retrovisor ficou pequeno na minha cb1000, mas fora isso é muito bom", "aleatorio", "nada", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carrinho",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carrinho",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comentario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comentario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mecanico",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mecanico",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Nome_Produto",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Cliente");
        }
    }
}
