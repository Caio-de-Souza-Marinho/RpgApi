using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "Personagens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Personagens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, null, null, null, null, new byte[] { 172, 118, 224, 183, 233, 85, 8, 213, 99, 127, 89, 74, 225, 201, 247, 127, 205, 40, 46, 52, 129, 62, 17, 204, 228, 31, 105, 173, 107, 9, 107, 131, 202, 253, 231, 37, 186, 150, 113, 91, 24, 89, 77, 71, 8, 83, 50, 193, 4, 119, 162, 81, 108, 103, 175, 217, 165, 12, 174, 232, 31, 174, 221, 129 }, new byte[] { 174, 104, 77, 194, 68, 11, 163, 66, 182, 155, 113, 199, 185, 169, 253, 26, 14, 33, 30, 246, 188, 8, 69, 39, 87, 204, 57, 72, 7, 35, 120, 131, 69, 57, 136, 0, 20, 26, 205, 5, 203, 2, 196, 28, 134, 104, 231, 56, 11, 23, 102, 137, 37, 185, 140, 89, 213, 174, 211, 157, 145, 151, 108, 191, 4, 77, 211, 220, 188, 116, 144, 252, 51, 205, 171, 189, 49, 133, 192, 147, 150, 37, 221, 249, 121, 20, 233, 9, 242, 38, 117, 252, 168, 37, 87, 67, 242, 126, 203, 92, 22, 33, 46, 199, 56, 158, 194, 67, 132, 101, 138, 168, 206, 79, 236, 89, 88, 107, 84, 181, 124, 114, 208, 51, 53, 36, 130, 151 }, "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Personagens");
        }
    }
}
