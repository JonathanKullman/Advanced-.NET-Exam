using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class FixedActivityAndLogger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Activities_Activities_ActivityId",
                table: "Logger_Activities");

            migrationBuilder.DropIndex(
                name: "IX_Logger_Activities_ActivityId",
                table: "Logger_Activities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Logger_Activities",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Logger_Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityLoggerId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActivityType",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfEnd",
                table: "Activities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfStart",
                table: "Activities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityLoggerId",
                table: "Activities",
                column: "ActivityLoggerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Logger_Activities_ActivityLoggerId",
                table: "Activities",
                column: "ActivityLoggerId",
                principalTable: "Logger_Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Logger_Activities_ActivityLoggerId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityLoggerId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityLoggerId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TimeOfEnd",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "TimeOfStart",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Logger_Activities",
                newName: "TimeStamp");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Logger_Activities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
