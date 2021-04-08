using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class FixedActivityAndLoggerMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Activities_ActivityId",
                table: "Hamsters");

            migrationBuilder.DropIndex(
                name: "IX_Hamsters_ActivityId",
                table: "Hamsters");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Logger_Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Hamsters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Logger_Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Hamsters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ActivityId",
                table: "Hamsters",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Activities_ActivityId",
                table: "Hamsters",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
