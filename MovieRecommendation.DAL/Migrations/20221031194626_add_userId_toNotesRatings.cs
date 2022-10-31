using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRecommendation.DAL.Migrations
{
    public partial class add_userId_toNotesRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovieRatings_UserId",
                table: "MovieRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieNotes_UserId",
                table: "MovieNotes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieNotes_Users_UserId",
                table: "MovieNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRatings_Users_UserId",
                table: "MovieRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieNotes_Users_UserId",
                table: "MovieNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieRatings_Users_UserId",
                table: "MovieRatings");

            migrationBuilder.DropIndex(
                name: "IX_MovieRatings_UserId",
                table: "MovieRatings");

            migrationBuilder.DropIndex(
                name: "IX_MovieNotes_UserId",
                table: "MovieNotes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieRatings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieNotes");
        }
    }
}
