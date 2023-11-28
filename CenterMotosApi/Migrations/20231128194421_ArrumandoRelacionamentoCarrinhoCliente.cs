using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CenterMotosApi.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoRelacionamentoCarrinhoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Carrinho_CarrinhoId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CarrinhoId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "ComentarioId",
                table: "Cliente",
                newName: "Comentarios");

            migrationBuilder.RenameColumn(
                name: "CarrinhoId",
                table: "Cliente",
                newName: "Carrinho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comentarios",
                table: "Cliente",
                newName: "ComentarioId");

            migrationBuilder.RenameColumn(
                name: "Carrinho",
                table: "Cliente",
                newName: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CarrinhoId",
                table: "Cliente",
                column: "CarrinhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Carrinho_CarrinhoId",
                table: "Cliente",
                column: "CarrinhoId",
                principalTable: "Carrinho",
                principalColumn: "Id");
        }
    }
}
