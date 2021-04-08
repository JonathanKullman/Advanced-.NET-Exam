using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class initupdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLoggers_Hamsters_HamsterId",
                table: "ActivityLoggers");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "ActivityLoggers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLoggers_Hamsters_HamsterId",
                table: "ActivityLoggers",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLoggers_Hamsters_HamsterId",
                table: "ActivityLoggers");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "ActivityLoggers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLoggers_Hamsters_HamsterId",
                table: "ActivityLoggers",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
