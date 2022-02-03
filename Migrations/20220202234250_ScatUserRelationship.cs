using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scat_chat_api.Migrations
{
    public partial class ScatUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Scats_UserId",
                table: "Scats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scats_Users_UserId",
                table: "Scats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scats_Users_UserId",
                table: "Scats");

            migrationBuilder.DropIndex(
                name: "IX_Scats_UserId",
                table: "Scats");
        }
    }
}
