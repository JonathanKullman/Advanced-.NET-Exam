using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class loggerfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Logger_Activities_Logger_ActivitiesId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Activities_Hamsters_HamsterId",
                table: "Logger_Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_Logger_ActivitiesId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Logger_ActivitiesId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "Logger_Activities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Logger_Activities",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 11,
                column: "Gender",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logger_Activities_ActivityId",
                table: "Logger_Activities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Activities_Activities_ActivityId",
                table: "Logger_Activities",
                column: "ActivityId",
                principalTable: "Activities",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Activities_Activities_ActivityId",
                table: "Logger_Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Activities_Hamsters_HamsterId",
                table: "Logger_Activities");

            migrationBuilder.DropIndex(
                name: "IX_Logger_Activities_ActivityId",
                table: "Logger_Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Logger_Activities");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "Logger_Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Logger_ActivitiesId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 11,
                column: "Gender",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Logger_ActivitiesId",
                table: "Activities",
                column: "Logger_ActivitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Logger_Activities_Logger_ActivitiesId",
                table: "Activities",
                column: "Logger_ActivitiesId",
                principalTable: "Logger_Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Activities_Hamsters_HamsterId",
                table: "Logger_Activities",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
