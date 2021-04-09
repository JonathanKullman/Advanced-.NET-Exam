using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CurrentActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CageId = table.Column<int>(type: "int", nullable: true),
                    ExerciseAreaId = table.Column<int>(type: "int", nullable: true),
                    OldCageId = table.Column<int>(type: "int", nullable: true),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeOfLastExercise = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hamsters_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_ExerciseAreas_ExerciseAreaId",
                        column: x => x.ExerciseAreaId,
                        principalTable: "ExerciseAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLoggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HamsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLoggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLoggers_Hamsters_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    TimeOfStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeOfEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivityLoggerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityLoggers_ActivityLoggerId",
                        column: x => x.ActivityLoggerId,
                        principalTable: "ActivityLoggers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cages",
                columns: new[] { "Id", "Gender", "MaxCapacity" },
                values: new object[,]
                {
                    { 1, 0, 3 },
                    { 2, 0, 3 },
                    { 3, 0, 3 },
                    { 4, 0, 3 },
                    { 5, 0, 3 },
                    { 6, 1, 3 },
                    { 7, 1, 3 },
                    { 8, 1, 3 },
                    { 9, 1, 3 },
                    { 10, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseAreas",
                columns: new[] { "Id", "Gender", "MaxCapacity" },
                values: new object[] { 1, null, 6 });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 15, "Mork of Ork" },
                    { 16, "Mindy Mendel" },
                    { 17, "GW Hansson" },
                    { 18, "Pia Hansson" },
                    { 19, "Bo Ek" },
                    { 24, "Anna Linström" },
                    { 21, "Hans Björk" },
                    { 22, "Carita Gran" },
                    { 23, "Mia Eriksson" },
                    { 14, "Kim Carnes" },
                    { 20, "Anna Al" },
                    { 13, "Bette Davis" },
                    { 8, "Pernilla Wahlgren" },
                    { 11, "Bobby Ewing" },
                    { 10, "Lorenzo Lamas" },
                    { 9, "Bianca Ingrosso" },
                    { 25, "Lennart Berg" },
                    { 7, "Anna Book" },
                    { 6, "Anfers Murkwood" },
                    { 5, "Ottilla Murkwood" },
                    { 4, "Jan Hallgren" },
                    { 3, "Lisa Nilsson" },
                    { 2, "Carl Hamilton" },
                    { 1, "Kallegurra Aktersnurra" },
                    { 12, "Hedy Lamar" },
                    { 26, "Bo Bergman" }
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "Age", "CageId", "CheckInTime", "CurrentActivity", "ExerciseAreaId", "Gender", "Name", "OldCageId", "OwnerId", "TimeOfLastExercise" },
                values: new object[,]
                {
                    { 1, 4, null, null, null, null, 0, "Rufus", null, 1, null },
                    { 28, 8, null, null, null, null, 0, "Marvel", null, 24, null },
                    { 27, 9, null, null, null, null, 1, "Mimmi", null, 23, null },
                    { 26, 110, null, null, null, null, 0, "Crawler", null, 22, null },
                    { 25, 12, null, null, null, null, 1, "Gittan", null, 21, null },
                    { 24, 14, null, null, null, null, 0, "Sauron", null, 20, null },
                    { 23, 15, null, null, null, null, 0, "Clint", null, 19, null },
                    { 22, 16, null, null, null, null, 1, "Neko", null, 18, null },
                    { 21, 16, null, null, null, null, 1, "Fiffi", null, 17, null },
                    { 20, 18, null, null, null, null, 1, "Ruby", null, 16, null },
                    { 19, 19, null, null, null, null, 1, "Kimber", null, 15, null },
                    { 18, 20, null, null, null, null, 1, "Amber", null, 14, null },
                    { 17, 21, null, null, null, null, 1, "Robin", null, 13, null },
                    { 16, 22, null, null, null, null, 1, "Bobo", null, 12, null },
                    { 15, 23, null, null, null, null, 0, "Beppe", null, 11, null },
                    { 14, 24, null, null, null, null, 0, "Bulle", null, 10, null },
                    { 13, 3, null, null, null, null, 1, "Malin", null, 9, null },
                    { 12, 3, null, null, null, null, 0, "Chivas", null, 8, null },
                    { 11, 4, null, null, null, null, 0, "Starlight", null, 7, null },
                    { 10, 4, null, null, null, null, 0, "Kurt", null, 7, null },
                    { 9, 5, null, null, null, null, 0, "Kalle", null, 6, null },
                    { 8, 6, null, null, null, null, 1, "Miss Diggy", null, 5, null },
                    { 7, 7, null, null, null, null, 1, "Mulan", null, 4, null },
                    { 6, 8, null, null, null, null, 1, "Sussi", null, 3, null },
                    { 5, 9, null, null, null, null, 0, "Sneaky", null, 3, null },
                    { 4, 10, null, null, null, null, 0, "Nibbler", null, 2, null },
                    { 3, 11, null, null, null, null, 0, "Fluff", null, 2, null },
                    { 2, 12, null, null, null, null, 1, "Lisa", null, 1, null },
                    { 29, 7, null, null, null, null, 0, "Storm", null, 25, null },
                    { 30, 6, null, null, null, null, 1, "Busan", null, 26, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityLoggerId",
                table: "Activities",
                column: "ActivityLoggerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLoggers_HamsterId",
                table: "ActivityLoggers",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_CageId",
                table: "Hamsters",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ExerciseAreaId",
                table: "Hamsters",
                column: "ExerciseAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_OwnerId",
                table: "Hamsters",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityLoggers");

            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropTable(
                name: "ExerciseAreas");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
