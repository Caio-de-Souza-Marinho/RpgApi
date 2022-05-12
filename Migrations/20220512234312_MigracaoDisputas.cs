using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoDisputas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Jogador");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Disputas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDisputa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtacanteId = table.Column<int>(type: "int", nullable: false),
                    OponenteId = table.Column<int>(type: "int", nullable: false),
                    Narracao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disputas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 92, 60, 212, 38, 29, 86, 115, 65, 76, 211, 197, 54, 229, 116, 114, 18, 73, 19, 106, 152, 44, 249, 196, 180, 99, 6, 7, 113, 214, 15, 128, 122, 237, 39, 158, 171, 15, 107, 6, 92, 45, 236, 92, 195, 151, 60, 255, 24, 116, 93, 208, 127, 116, 73, 254, 98, 204, 155, 143, 253, 166, 147, 152, 172 }, new byte[] { 132, 18, 98, 67, 71, 230, 62, 123, 100, 118, 43, 153, 114, 185, 83, 167, 32, 231, 160, 24, 71, 39, 178, 230, 51, 42, 213, 25, 128, 93, 68, 241, 204, 11, 170, 139, 28, 185, 39, 140, 137, 102, 156, 228, 211, 100, 88, 218, 105, 112, 137, 20, 40, 55, 248, 123, 160, 179, 76, 245, 67, 230, 29, 16, 183, 199, 120, 208, 68, 150, 110, 166, 211, 124, 100, 170, 43, 61, 30, 38, 151, 254, 21, 100, 193, 46, 86, 97, 81, 73, 152, 125, 124, 157, 235, 224, 6, 78, 136, 164, 35, 40, 25, 196, 240, 98, 188, 68, 218, 3, 155, 71, 247, 134, 157, 18, 139, 213, 16, 40, 81, 59, 245, 67, 65, 219, 112, 86 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disputas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 102, 157, 153, 37, 7, 62, 76, 78, 121, 61, 92, 163, 125, 245, 1, 165, 63, 219, 240, 211, 29, 121, 198, 240, 118, 218, 225, 158, 65, 41, 82, 236, 125, 164, 170, 8, 243, 95, 21, 82, 143, 122, 190, 39, 63, 158, 7, 169, 159, 179, 201, 229, 93, 79, 54, 179, 229, 99, 175, 164, 114, 97, 67 }, new byte[] { 227, 188, 75, 250, 3, 244, 145, 221, 161, 38, 33, 141, 34, 95, 116, 147, 190, 218, 123, 5, 122, 62, 114, 9, 137, 113, 219, 201, 159, 126, 172, 63, 113, 109, 190, 254, 225, 252, 181, 211, 200, 91, 232, 2, 243, 76, 148, 254, 85, 120, 199, 197, 209, 142, 238, 62, 65, 28, 165, 50, 174, 178, 66, 73, 204, 215, 197, 248, 177, 75, 67, 217, 193, 244, 252, 45, 249, 255, 139, 170, 79, 4, 122, 178, 53, 34, 249, 96, 7, 63, 140, 63, 129, 109, 174, 175, 6, 200, 104, 87, 204, 154, 139, 193, 118, 129, 243, 61, 131, 24, 37, 188, 253, 211, 222, 81, 252, 93, 182, 113, 85, 139, 74, 107, 121, 31, 199, 78 } });
        }
    }
}
