using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class FixedActivityAndLoggerMore2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Logger_Activities_ActivityLoggerId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Cage_CageId",
                table: "Hamsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Activities_Hamsters_HamsterId",
                table: "Logger_Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logger_Activities",
                table: "Logger_Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cage",
                table: "Cage");

            migrationBuilder.RenameTable(
                name: "Logger_Activities",
                newName: "ActivityLoggers");

            migrationBuilder.RenameTable(
                name: "Cage",
                newName: "Cages");

            migrationBuilder.RenameIndex(
                name: "IX_Logger_Activities_HamsterId",
                table: "ActivityLoggers",
                newName: "IX_ActivityLoggers_HamsterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityLoggers",
                table: "ActivityLoggers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cages",
                table: "Cages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityLoggers_ActivityLoggerId",
                table: "Activities",
                column: "ActivityLoggerId",
                principalTable: "ActivityLoggers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLoggers_Hamsters_HamsterId",
                table: "ActivityLoggers",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Cages_CageId",
                table: "Hamsters",
                column: "CageId",
                principalTable: "Cages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityLoggers_ActivityLoggerId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLoggers_Hamsters_HamsterId",
                table: "ActivityLoggers");

            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Cages_CageId",
                table: "Hamsters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cages",
                table: "Cages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityLoggers",
                table: "ActivityLoggers");

            migrationBuilder.RenameTable(
                name: "Cages",
                newName: "Cage");

            migrationBuilder.RenameTable(
                name: "ActivityLoggers",
                newName: "Logger_Activities");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityLoggers_HamsterId",
                table: "Logger_Activities",
                newName: "IX_Logger_Activities_HamsterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cage",
                table: "Cage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logger_Activities",
                table: "Logger_Activities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Logger_Activities_ActivityLoggerId",
                table: "Activities",
                column: "ActivityLoggerId",
                principalTable: "Logger_Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Cage_CageId",
                table: "Hamsters",
                column: "CageId",
                principalTable: "Cage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Activities_Hamsters_HamsterId",
                table: "Logger_Activities",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
