using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaDemo.Migrations
{
    /// <inheritdoc />
    public partial class Clinica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCita",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "HistorialClinico");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Citas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCita",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "HistorialClinico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
