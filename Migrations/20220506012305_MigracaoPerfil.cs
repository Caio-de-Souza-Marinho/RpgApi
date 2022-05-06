using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 221, 102, 157, 153, 37, 7, 62, 76, 78, 121, 61, 92, 163, 125, 245, 1, 165, 63, 219, 240, 211, 29, 121, 198, 240, 118, 218, 225, 158, 65, 41, 82, 236, 125, 164, 170, 8, 243, 95, 21, 82, 143, 122, 190, 39, 63, 158, 7, 169, 159, 179, 201, 229, 93, 79, 54, 179, 229, 99, 175, 164, 114, 97, 67 }, new byte[] { 227, 188, 75, 250, 3, 244, 145, 221, 161, 38, 33, 141, 34, 95, 116, 147, 190, 218, 123, 5, 122, 62, 114, 9, 137, 113, 219, 201, 159, 126, 172, 63, 113, 109, 190, 254, 225, 252, 181, 211, 200, 91, 232, 2, 243, 76, 148, 254, 85, 120, 199, 197, 209, 142, 238, 62, 65, 28, 165, 50, 174, 178, 66, 73, 204, 215, 197, 248, 177, 75, 67, 217, 193, 244, 252, 45, 249, 255, 139, 170, 79, 4, 122, 178, 53, 34, 249, 96, 7, 63, 140, 63, 129, 109, 174, 175, 6, 200, 104, 87, 204, 154, 139, 193, 118, 129, 243, 61, 131, 24, 37, 188, 253, 211, 222, 81, 252, 93, 182, 113, 85, 139, 74, 107, 121, 31, 199, 78 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 124, 18, 75, 60, 175, 40, 41, 33, 73, 203, 194, 147, 35, 46, 54, 166, 6, 92, 224, 33, 214, 248, 223, 116, 80, 124, 234, 142, 94, 112, 170, 81, 129, 73, 151, 41, 128, 255, 93, 197, 121, 233, 166, 239, 178, 81, 240, 71, 161, 26, 220, 167, 115, 195, 206, 30, 208, 169, 167, 57, 100, 43, 210, 162 }, new byte[] { 114, 172, 237, 103, 162, 249, 16, 81, 41, 209, 123, 185, 76, 139, 192, 71, 12, 215, 243, 197, 55, 107, 111, 195, 215, 251, 52, 178, 139, 180, 201, 63, 76, 202, 161, 29, 78, 22, 191, 135, 65, 104, 138, 41, 17, 250, 230, 127, 105, 232, 244, 204, 41, 26, 223, 112, 108, 13, 68, 222, 132, 145, 28, 240, 188, 165, 15, 115, 50, 57, 238, 123, 97, 153, 197, 89, 117, 23, 198, 206, 59, 86, 226, 22, 247, 244, 144, 199, 214, 49, 230, 98, 11, 223, 232, 202, 160, 211, 76, 229, 80, 221, 174, 110, 153, 156, 11, 88, 204, 72, 48, 24, 99, 142, 98, 35, 98, 66, 240, 9, 253, 245, 101, 240, 36, 35, 234, 172 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId");
        }
    }
}
