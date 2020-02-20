using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudEnfermeiros.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospitais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeiros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompleto = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Coren = table.Column<string>(nullable: true),
                    DataDeNasciento = table.Column<DateTime>(nullable: false),
                    HospitalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermeiros_Hospitais_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeiros_HospitalId",
                table: "Enfermeiros",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfermeiros");

            migrationBuilder.DropTable(
                name: "Hospitais");
        }
    }
}
