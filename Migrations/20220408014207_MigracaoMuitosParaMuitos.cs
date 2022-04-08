using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 124, 18, 75, 60, 175, 40, 41, 33, 73, 203, 194, 147, 35, 46, 54, 166, 6, 92, 224, 33, 214, 248, 223, 116, 80, 124, 234, 142, 94, 112, 170, 81, 129, 73, 151, 41, 128, 255, 93, 197, 121, 233, 166, 239, 178, 81, 240, 71, 161, 26, 220, 167, 115, 195, 206, 30, 208, 169, 167, 57, 100, 43, 210, 162 }, new byte[] { 114, 172, 237, 103, 162, 249, 16, 81, 41, 209, 123, 185, 76, 139, 192, 71, 12, 215, 243, 197, 55, 107, 111, 195, 215, 251, 52, 178, 139, 180, 201, 63, 76, 202, 161, 29, 78, 22, 191, 135, 65, 104, 138, 41, 17, 250, 230, 127, 105, 232, 244, 204, 41, 26, 223, 112, 108, 13, 68, 222, 132, 145, 28, 240, 188, 165, 15, 115, 50, 57, 238, 123, 97, 153, 197, 89, 117, 23, 198, 206, 59, 86, 226, 22, 247, 244, 144, 199, 214, 49, 230, 98, 11, 223, 232, 202, 160, 211, 76, 229, 80, 221, 174, 110, 153, 156, 11, 88, 204, 72, 48, 24, 99, 142, 98, 35, 98, 66, 240, 9, 253, 245, 101, 240, 36, 35, 234, 172 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 6 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 127, 14, 37, 167, 220, 19, 212, 199, 143, 28, 151, 80, 186, 253, 37, 90, 203, 165, 250, 148, 115, 51, 67, 166, 186, 7, 200, 212, 12, 92, 72, 214, 156, 239, 84, 74, 117, 98, 196, 214, 31, 103, 225, 194, 166, 127, 47, 165, 116, 191, 75, 84, 237, 154, 111, 209, 60, 207, 190, 75, 8, 24, 225, 91 }, new byte[] { 47, 94, 143, 53, 68, 241, 85, 91, 50, 51, 128, 57, 177, 3, 106, 195, 148, 38, 54, 166, 211, 40, 235, 163, 65, 217, 180, 7, 142, 102, 250, 37, 195, 250, 163, 219, 51, 183, 8, 60, 85, 72, 179, 43, 105, 9, 72, 172, 33, 57, 92, 73, 84, 28, 17, 179, 182, 160, 242, 29, 91, 88, 154, 145, 43, 180, 157, 59, 107, 202, 156, 63, 53, 66, 167, 129, 237, 143, 12, 22, 177, 3, 52, 200, 238, 216, 102, 212, 250, 231, 249, 241, 150, 45, 130, 164, 101, 209, 73, 242, 83, 170, 123, 184, 213, 138, 83, 250, 33, 4, 192, 215, 100, 110, 33, 142, 147, 237, 225, 78, 198, 67, 26, 145, 126, 46, 215, 112 } });
        }
    }
}
