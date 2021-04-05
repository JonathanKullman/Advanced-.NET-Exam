using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kallegurra Aktersnurra" },
                    { 24, "Anna Linström" },
                    { 23, "Mia Eriksson" },
                    { 22, "Carita Gran" },
                    { 21, "Hans Björk" },
                    { 20, "Anna Al" },
                    { 19, "Bo Ek" },
                    { 18, "Pia Hansson" },
                    { 17, "GW Hansson" },
                    { 16, "Mindy Mendel" },
                    { 15, "Mork of Ork" },
                    { 14, "Kim Carnes" },
                    { 13, "Bette Davis" },
                    { 12, "Hedy Lamar" },
                    { 11, "Bobby Ewing" },
                    { 10, "Lorenzo Lamas" },
                    { 9, "Bianca Ingrosso" },
                    { 8, "Pernilla Wahlgren" },
                    { 7, "Anna Book" },
                    { 6, "Anfers Murkwood" },
                    { 5, "Ottilla Murkwood" },
                    { 4, "Jan Hallgren" },
                    { 3, "Lisa Nilsson" },
                    { 2, "Carl Hamilton" },
                    { 25, "Lennart Berg" },
                    { 26, "Bo Bergman" }
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "ActivityId", "Age", "CageBuddiesId", "CheckInTime", "Gender", "Name", "OwnerId", "TimeOfLastExercise" },
                values: new object[,]
                {
                    { 1, null, 4, null, null, 0, "Rufus", 1, null },
                    { 28, null, 8, null, null, 0, "Marvel", 24, null },
                    { 27, null, 9, null, null, 1, "Mimmi", 23, null },
                    { 26, null, 110, null, null, 0, "Crawler", 22, null },
                    { 25, null, 12, null, null, 1, "Gittan", 21, null },
                    { 24, null, 14, null, null, 0, "Sauron", 20, null },
                    { 23, null, 15, null, null, 0, "Clint", 19, null },
                    { 22, null, 16, null, null, 1, "Neko", 18, null },
                    { 21, null, 16, null, null, 1, "Fiffi", 17, null },
                    { 20, null, 18, null, null, 1, "Ruby", 16, null },
                    { 19, null, 19, null, null, 1, "Kimber", 15, null },
                    { 18, null, 20, null, null, 1, "Amber", 14, null },
                    { 17, null, 21, null, null, 1, "Robin", 13, null },
                    { 16, null, 22, null, null, 1, "Bobo", 12, null },
                    { 15, null, 23, null, null, 0, "Beppe", 11, null },
                    { 14, null, 24, null, null, 0, "Bulle", 10, null },
                    { 13, null, 3, null, null, 1, "Malin", 9, null },
                    { 12, null, 3, null, null, 0, "Chivas", 8, null },
                    { 11, null, 4, null, null, 1, "Starlight", 7, null },
                    { 10, null, 4, null, null, 0, "Kurt", 7, null },
                    { 9, null, 5, null, null, 0, "Kalle", 6, null },
                    { 8, null, 6, null, null, 1, "Miss Diggy", 5, null },
                    { 7, null, 7, null, null, 1, "Mulan", 4, null },
                    { 6, null, 8, null, null, 1, "Sussi", 3, null },
                    { 5, null, 9, null, null, 0, "Sneaky", 3, null },
                    { 4, null, 10, null, null, 0, "Nibbler", 2, null },
                    { 3, null, 11, null, null, 0, "Fluff", 2, null },
                    { 2, null, 12, null, null, 1, "Lisa", 1, null },
                    { 29, null, 7, null, null, 0, "Storm", 25, null },
                    { 30, null, 6, null, null, 1, "Busan", 26, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 26);
        }
    }
}
