using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoUmParaUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Dano", "Nome", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 35, "Arco e Flecha", 1 },
                    { 2, 33, "Espada", 2 },
                    { 3, 31, "Machado", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 127, 14, 37, 167, 220, 19, 212, 199, 143, 28, 151, 80, 186, 253, 37, 90, 203, 165, 250, 148, 115, 51, 67, 166, 186, 7, 200, 212, 12, 92, 72, 214, 156, 239, 84, 74, 117, 98, 196, 214, 31, 103, 225, 194, 166, 127, 47, 165, 116, 191, 75, 84, 237, 154, 111, 209, 60, 207, 190, 75, 8, 24, 225, 91 }, new byte[] { 47, 94, 143, 53, 68, 241, 85, 91, 50, 51, 128, 57, 177, 3, 106, 195, 148, 38, 54, 166, 211, 40, 235, 163, 65, 217, 180, 7, 142, 102, 250, 37, 195, 250, 163, 219, 51, 183, 8, 60, 85, 72, 179, 43, 105, 9, 72, 172, 33, 57, 92, 73, 84, 28, 17, 179, 182, 160, 242, 29, 91, 88, 154, 145, 43, 180, 157, 59, 107, 202, 156, 63, 53, 66, 167, 129, 237, 143, 12, 22, 177, 3, 52, 200, 238, 216, 102, 212, 250, 231, 249, 241, 150, 45, 130, 164, 101, 209, 73, 242, 83, 170, 123, 184, 213, 138, 83, 250, 33, 4, 192, 215, 100, 110, 33, 142, 147, 237, 225, 78, 198, 67, 26, 145, 126, 46, 215, 112 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 172, 118, 224, 183, 233, 85, 8, 213, 99, 127, 89, 74, 225, 201, 247, 127, 205, 40, 46, 52, 129, 62, 17, 204, 228, 31, 105, 173, 107, 9, 107, 131, 202, 253, 231, 37, 186, 150, 113, 91, 24, 89, 77, 71, 8, 83, 50, 193, 4, 119, 162, 81, 108, 103, 175, 217, 165, 12, 174, 232, 31, 174, 221, 129 }, new byte[] { 174, 104, 77, 194, 68, 11, 163, 66, 182, 155, 113, 199, 185, 169, 253, 26, 14, 33, 30, 246, 188, 8, 69, 39, 87, 204, 57, 72, 7, 35, 120, 131, 69, 57, 136, 0, 20, 26, 205, 5, 203, 2, 196, 28, 134, 104, 231, 56, 11, 23, 102, 137, 37, 185, 140, 89, 213, 174, 211, 157, 145, 151, 108, 191, 4, 77, 211, 220, 188, 116, 144, 252, 51, 205, 171, 189, 49, 133, 192, 147, 150, 37, 221, 249, 121, 20, 233, 9, 242, 38, 117, 252, 168, 37, 87, 67, 242, 126, 203, 92, 22, 33, 46, 199, 56, 158, 194, 67, 132, 101, 138, 168, 206, 79, 236, 89, 88, 107, 84, 181, 124, 114, 208, 51, 53, 36, 130, 151 } });
        }
    }
}
