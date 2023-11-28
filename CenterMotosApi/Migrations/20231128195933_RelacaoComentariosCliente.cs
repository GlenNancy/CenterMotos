using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CenterMotosApi.Migrations
{
    /// <inheritdoc />
    public partial class RelacaoComentariosCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Comentario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ClienteId",
                table: "Comentario",
                column: "ClienteId");

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
                name: "FK_Comentario_Cliente_ClienteId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_ClienteId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Comentario");

            migrationBuilder.AddColumn<int>(
                name: "Comentarios",
                table: "Cliente",
                type: "int",
                nullable: true);
        }
    }
}
