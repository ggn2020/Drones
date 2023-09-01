using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drones.Domain.Migrations
{
    /// <inheritdoc />
    public partial class fixdroneconf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Drones_Modelo",
                table: "Drones");

            migrationBuilder.CreateIndex(
                name: "IX_Drones_NumeroSerie",
                table: "Drones",
                column: "NumeroSerie",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Drones_NumeroSerie",
                table: "Drones");

            migrationBuilder.CreateIndex(
                name: "IX_Drones_Modelo",
                table: "Drones",
                column: "Modelo",
                unique: true);
        }
    }
}
