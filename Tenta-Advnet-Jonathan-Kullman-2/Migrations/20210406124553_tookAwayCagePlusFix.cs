using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_Advnet_Jonathan_Kullman_2.Migrations
{
    public partial class tookAwayCagePlusFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Cage_CageBuddiesId",
                table: "Hamsters");

            migrationBuilder.RenameColumn(
                name: "CageBuddiesId",
                table: "Hamsters",
                newName: "CageId");

            migrationBuilder.RenameIndex(
                name: "IX_Hamsters_CageBuddiesId",
                table: "Hamsters",
                newName: "IX_Hamsters_CageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Cage_CageId",
                table: "Hamsters",
                column: "CageId",
                principalTable: "Cage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Cage_CageId",
                table: "Hamsters");

            migrationBuilder.RenameColumn(
                name: "CageId",
                table: "Hamsters",
                newName: "CageBuddiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Hamsters_CageId",
                table: "Hamsters",
                newName: "IX_Hamsters_CageBuddiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Cage_CageBuddiesId",
                table: "Hamsters",
                column: "CageBuddiesId",
                principalTable: "Cage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
