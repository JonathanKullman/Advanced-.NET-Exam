using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class addedGenderToCages_initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cage", x => x.Id);
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
                    ActivityId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Hamsters_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hamsters_Cage_CageId",
                        column: x => x.CageId,
                        principalTable: "Cage",
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
                name: "Logger_Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HamsterId = table.Column<int>(type: "int", nullable: true),
                    ActivityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logger_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logger_Activities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logger_Activities_Hamsters_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cage",
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
                columns: new[] { "Id", "ActivityId", "Age", "CageId", "CheckInTime", "CurrentActivity", "ExerciseAreaId", "Gender", "Name", "OldCageId", "OwnerId", "TimeOfLastExercise" },
                values: new object[,]
                {
                    { 1, null, 4, null, null, null, null, 0, "Rufus", null, 1, null },
                    { 28, null, 8, null, null, null, null, 0, "Marvel", null, 24, null },
                    { 27, null, 9, null, null, null, null, 1, "Mimmi", null, 23, null },
                    { 26, null, 110, null, null, null, null, 0, "Crawler", null, 22, null },
                    { 25, null, 12, null, null, null, null, 1, "Gittan", null, 21, null },
                    { 24, null, 14, null, null, null, null, 0, "Sauron", null, 20, null },
                    { 23, null, 15, null, null, null, null, 0, "Clint", null, 19, null },
                    { 22, null, 16, null, null, null, null, 1, "Neko", null, 18, null },
                    { 21, null, 16, null, null, null, null, 1, "Fiffi", null, 17, null },
                    { 20, null, 18, null, null, null, null, 1, "Ruby", null, 16, null },
                    { 19, null, 19, null, null, null, null, 1, "Kimber", null, 15, null },
                    { 18, null, 20, null, null, null, null, 1, "Amber", null, 14, null },
                    { 17, null, 21, null, null, null, null, 1, "Robin", null, 13, null },
                    { 16, null, 22, null, null, null, null, 1, "Bobo", null, 12, null },
                    { 15, null, 23, null, null, null, null, 0, "Beppe", null, 11, null },
                    { 14, null, 24, null, null, null, null, 0, "Bulle", null, 10, null },
                    { 13, null, 3, null, null, null, null, 1, "Malin", null, 9, null },
                    { 12, null, 3, null, null, null, null, 0, "Chivas", null, 8, null },
                    { 11, null, 4, null, null, null, null, 0, "Starlight", null, 7, null },
                    { 10, null, 4, null, null, null, null, 0, "Kurt", null, 7, null },
                    { 9, null, 5, null, null, null, null, 0, "Kalle", null, 6, null },
                    { 8, null, 6, null, null, null, null, 1, "Miss Diggy", null, 5, null },
                    { 7, null, 7, null, null, null, null, 1, "Mulan", null, 4, null },
                    { 6, null, 8, null, null, null, null, 1, "Sussi", null, 3, null },
                    { 5, null, 9, null, null, null, null, 0, "Sneaky", null, 3, null },
                    { 4, null, 10, null, null, null, null, 0, "Nibbler", null, 2, null },
                    { 3, null, 11, null, null, null, null, 0, "Fluff", null, 2, null },
                    { 2, null, 12, null, null, null, null, 1, "Lisa", null, 1, null },
                    { 29, null, 7, null, null, null, null, 0, "Storm", null, 25, null },
                    { 30, null, 6, null, null, null, null, 1, "Busan", null, 26, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ActivityId",
                table: "Hamsters",
                column: "ActivityId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Logger_Activities_ActivityId",
                table: "Logger_Activities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Logger_Activities_HamsterId",
                table: "Logger_Activities",
                column: "HamsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logger_Activities");

            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Cage");

            migrationBuilder.DropTable(
                name: "ExerciseAreas");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
