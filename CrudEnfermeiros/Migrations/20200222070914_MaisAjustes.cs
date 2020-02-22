using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudEnfermeiros.Migrations
{
    public partial class MaisAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfermeiros_Hospitais_HospitalId",
                table: "Enfermeiros");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Enfermeiros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enfermeiros_Hospitais_HospitalId",
                table: "Enfermeiros",
                column: "HospitalId",
                principalTable: "Hospitais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfermeiros_Hospitais_HospitalId",
                table: "Enfermeiros");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "Enfermeiros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Enfermeiros_Hospitais_HospitalId",
                table: "Enfermeiros",
                column: "HospitalId",
                principalTable: "Hospitais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
