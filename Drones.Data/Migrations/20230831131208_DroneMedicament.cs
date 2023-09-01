using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drones.Domain.Migrations
{
    /// <inheritdoc />
    public partial class DroneMedicament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DroneMedicament",
                columns: table => new
                {
                    DroneId = table.Column<int>(type: "int", nullable: false),
                    MedicamentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneMedicament", x => new { x.DroneId, x.MedicamentsId });
                    table.ForeignKey(
                        name: "FK_DroneMedicament_Drones_DroneId",
                        column: x => x.DroneId,
                        principalTable: "Drones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DroneMedicament_Medicamentos_MedicamentsId",
                        column: x => x.MedicamentsId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DroneMedicament_MedicamentsId",
                table: "DroneMedicament",
                column: "MedicamentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DroneMedicament");
        }
    }
}
