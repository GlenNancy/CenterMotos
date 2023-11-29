using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CenterMotosApi.Migrations
{
    /// <inheritdoc />
    public partial class Carrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComentarioId",
                table: "Mecanico");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Mecanico");

            migrationBuilder.DropColumn(
                name: "Carrinho",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Comentarios",
                table: "Cliente",
                newName: "CarrinhoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Mecanico",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Comentario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cliente",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ClienteId",
                table: "Comentario",
                column: "ClienteId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Cliente_ClienteId",
                table: "Comentario",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Carrinho_CarrinhoId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Cliente_ClienteId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_ClienteId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CarrinhoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "CarrinhoId",
                table: "Cliente",
                newName: "Comentarios");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Mecanico",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "ComentarioId",
                table: "Mecanico",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Mecanico",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cliente",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "Carrinho",
                table: "Cliente",
                type: "int",
                nullable: true);
        }
    }
}
