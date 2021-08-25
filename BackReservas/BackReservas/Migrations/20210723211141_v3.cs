using Microsoft.EntityFrameworkCore.Migrations;

namespace BackReservas.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idevento",
                table: "Reserva",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "estadoevento",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idevento",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "estadoevento",
                table: "Eventos");
        }
    }
}
